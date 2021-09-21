using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Araumi.Server.EntityComponentSystem.Components.Battle.Movement;
using Araumi.Server.EntityComponentSystem.Core;
using Araumi.Server.EntityComponentSystem.Events.Battle.Movement;
using Araumi.Server.Protocol.Attributes;
using Araumi.Server.Protocol.Exceptions;
using Araumi.Server.Services.Servers.Game;

using Fasterflect;

namespace Araumi.Server.Protocol {
  public class DataDecoder {
    private readonly BinaryReader _reader;
    private readonly OptionalMap _optionalMap;

    /// <summary>
    /// Temporary solution (until ECS will be fully implemented)
    /// to ignore packets that contain invalid / removed entities.
    /// </summary>
    public bool IsCommandIgnored { get; private set; }

    public DataDecoder(BinaryReader reader) {
      _reader = reader;
      _optionalMap = new OptionalMap();
    }

    public DataDecoder(BinaryReader reader, OptionalMap optionalMap) {
      _reader = reader;
      _optionalMap = optionalMap;
    }

    public object DecodePrimitive(Type type) {
      Type readerType = _reader.GetType();

      MethodInfo? method = readerType.GetMethod($"Read{type.Name}");
      if(method == null) throw new NotSupportedException($"Cannot decode type: {type}");

      return method.Invoke(_reader, Array.Empty<object>());
    }

    public int DecodeLength() {
      byte num1 = _reader.ReadByte();
      if((num1 & 0x80) == 0) return num1;

      byte num2 = _reader.ReadByte();
      if((num1 & 0x40) == 0) return ((num1 & 0x3F) << 8) + (num2 & 0xFF);

      byte num3 = _reader.ReadByte();
      return ((num1 & 0x3F) << 16) + ((num2 & 0xFF) << 8) + (num3 & 0xFF);
    }

    public string DecodeString() {
      int length = DecodeLength();
      byte[] data = _reader.ReadBytes(length);

      return Encoding.UTF8.GetString(data);
    }

    public DateTime DecodeDateTime() {
      return new DateTime(DateTime.UnixEpoch.Ticks + _reader.ReadInt64() * TimeSpan.TicksPerMillisecond);
    }

    public Vector3 DecodeVector3() {
      return new Vector3(_reader.ReadSingle(), _reader.ReadSingle(), _reader.ReadSingle());
    }

    private async Task<ICommand> DecodeCommand(Player player) {
      Type type = CommandUtils.GetCommandType(_reader.ReadByte());

      return (ICommand)await DecodeObject(type, player);
    }

    public MoveCommand DecodeMoveCommand() {
      bool hasMovement = _optionalMap.Read();
      bool hasWeaponRotation = _optionalMap.Read();
      bool isDiscrete = _optionalMap.Read();

      MoveCommand command = new MoveCommand();
      if(isDiscrete) {
        DiscreteTankControl control = new DiscreteTankControl() {
          Control = _reader.ReadByte()
        };

        command.TankControlHorizontal = control.TurnAxis;
        command.TankControlVertical = control.MoveAxis;
        command.WeaponRotationControl = control.WeaponControl;
      } else {
        command.TankControlVertical = _reader.ReadSingle();
        command.TankControlHorizontal = _reader.ReadSingle();
        command.WeaponRotationControl = _reader.ReadSingle();
      }

      if(hasMovement) {
        command.Movement = MovementCodec.Decode(_reader);
      }

      if(hasWeaponRotation) {
        byte[] weaponRotationBuffer = new byte[CommandUtils.WeaponRotationSize];

        _reader.Read(weaponRotationBuffer);
        BitArray weaponRotation = new BitArray(weaponRotationBuffer);
        // AbstractMoveCodec.CopyBits(weaponRotationBuffer, weaponRotation);

        int position = 0;

        command.WeaponRotation = AbstractMoveCodec.ReadFloat(
          weaponRotation, ref position,
          CommandUtils.WeaponRotationComponentBitsize, CommandUtils.WeaponRotationFactor
        );

        if(position != weaponRotation.Length) throw new InvalidOperationException("MoveCommand decode mismatch");
      }

      command.ClientTime = _reader.ReadInt32();

      return command;
    }

    public Movement DecodeMovement() {
      return MovementCodec.Decode(_reader);
    }

    public Type DecodeType() {
      return TypeUidUtils.GetTypeById(_reader.ReadInt64());
    }

    public Entity? DecodeEntity(Player player) {
      long id = _reader.ReadInt64();
      player.Entities.TryGetValue(id, out Entity? entity);
      return entity;
    }

    private async Task<T?> SelectDecode<T>(Player player) {
      return (T?)await SelectDecode(typeof(T), player);
    }

    private async Task<object?> SelectDecode(Type type, Player player) {
      if(type.IsPrimitive || type == typeof(decimal)) return DecodePrimitive(type);
      if(type == typeof(string)) return DecodeString();
      if(type == typeof(Vector3)) return DecodeVector3();
      if(type == typeof(MoveCommand)) return DecodeMoveCommand();
      if(type == typeof(Movement)) return DecodeMovement();
      if(type == typeof(Type)) return DecodeType();
      if(type == typeof(DateTime)) return DecodeDateTime();
      if(type.IsEnum) return Enum.ToObject(type, _reader.ReadByte());
      if(type == typeof(Entity)) return DecodeEntity(player);

      // if(typeof(DateTimeOffset).IsAssignableFrom(objType)) {
      //   long time = _reader.ReadInt64();
      //   return DateTimeOffset.FromUnixTimeMilliseconds(time + player.Connection.DifferenceToClient);
      // }

      // if(typeof(IDictionary).IsAssignableFrom(type)) {
      //   throw new NotImplementedException();
      // }

      if(type.IsArray || type.IsGenericType && typeof(ICollection<>).MakeGenericType(type.GetGenericArguments()[0]).IsAssignableFrom(type)) {
        return await DecodeCollection(type, player);
      }

      if(typeof(ICommand).IsAssignableFrom(type)) return await DecodeCommand(player);

      if(type.IsAbstract || type.IsInterface) {
        type = DecodeType();
        return await UnwrapPacket(player, type);
      }

      return await DecodeObject(type, player);
    }

    private async Task<object> DecodeCollection(Type type, Player player) {
      int length = DecodeLength();

      if(type.IsArray) {
        Type elementType = type.GetElementType();
        Array array = Array.CreateInstance(elementType, length);

        for(int index = 0; index < length; index++) {
          object? item = await SelectDecode(elementType, player);

          if(elementType == typeof(Entity) && item == null) {
            IsCommandIgnored = true;
            continue;
          }

          array.SetValue(item, index);
        }

        return array;
      }

      object instance = type.CreateInstance();
      Type collectionInnerType = type.GetGenericArguments()[0];

      for(int i = 0; i < length; i++) {
        object element = SelectDecode(collectionInnerType, player);
        // if(collectionInnerType == typeof(Entity) && item == null) continue;

        instance.CallMethod("Add", new Type[] { collectionInnerType }, element);
      }

      return instance;
    }

    public async Task<T> DecodeObject<T>(Player player) {
      return (T)await DecodeObject(typeof(T), player);
    }

    public async Task<object> DecodeObject(Type type, Player player) {
      // object instance = type.CreateInstance();
      object instance = FormatterServices.GetUninitializedObject(type);

      foreach(PropertyInfo property in CommandUtils.GetProtocolProperties(type)) {
        if(Attribute.IsDefined(property, typeof(ProtocolOptionalAttribute))) {
          bool isNull = _optionalMap.Read();
          if(isNull) continue; // Skip null value
        }

        object? value = await SelectDecode(property.PropertyType, player);
        if(property.PropertyType == typeof(Entity) && value == null) {
          IsCommandIgnored = true;
          continue;
        }

        property.SetValue(instance, value);
      }

      return instance;
    }

    public async Task<object> UnwrapPacket(Player player, Type? type = null) {
      byte[] header = _reader.ReadBytes(CommandUtils.PacketHeader.Length);
      if(header.Length < CommandUtils.PacketHeader.Length || !header.SequenceEqual(CommandUtils.PacketHeader)) {
        // Check if it is HTTP GET request
        byte[] httpHeader = new byte[CommandUtils.HttpGetHeader.Length];
        header.CopyTo(httpHeader, 0);
        _reader.ReadBytes(CommandUtils.HttpGetHeader.Length - header.Length).CopyTo(httpHeader, header.Length);

        bool isHttp = httpHeader.SequenceEqual(CommandUtils.HttpGetHeader);

        throw new InvalidPacketHeaderException(CommandUtils.PacketHeader, header, isHttp);
      }

      int optionalMapLength = _reader.ReadInt32();
      int dataLength = _reader.ReadInt32();

      int optionalMapByteLength = (int)Math.Ceiling(optionalMapLength / 8.0);
      byte[] optionalMapData = _reader.ReadBytes(optionalMapByteLength);
      OptionalMap optionalMap = new OptionalMap(optionalMapData, optionalMapLength);

      await using MemoryStream stream = new MemoryStream(_reader.ReadBytes(dataLength));
      BinaryReader dataReader = new BigEndianBinaryReader(stream);
      DataDecoder dataDecoder = new DataDecoder(dataReader, optionalMap);

      if(type != null) {
        object instance = await dataDecoder.DecodeObject(type, player);
        IsCommandIgnored |= dataDecoder.IsCommandIgnored;
        return instance;
      }

      List<ICommand> commands = new List<ICommand>();

      while(dataReader.BaseStream.Position != dataLength) {
        ICommand? command = await dataDecoder.SelectDecode<ICommand>(player);
        if(dataDecoder.IsCommandIgnored) {
          dataDecoder.IsCommandIgnored = false;
          continue;
        }

        if(command == null) throw new InvalidOperationException("Failed to decode command");
        commands.Add(command);
      }

      return commands;
    }

    public async Task<List<ICommand>> DecodeCommands(Player player) => (List<ICommand>)await UnwrapPacket(player);
  }
}
