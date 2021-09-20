using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Araumi.Server.EntityComponentSystem.Components.Battle.Movement;
using Araumi.Server.EntityComponentSystem.Core;
using Araumi.Server.EntityComponentSystem.Events.Battle.Movement;
using Araumi.Server.Extensions;
using Araumi.Server.Protocol.Attributes;
using Araumi.Server.Protocol.Exceptions;
using Araumi.Server.Services.Servers.Game;

using Fasterflect;

using Serilog;

namespace Araumi.Server.Protocol {
  public class DataEncoder {
    private static readonly ILogger Logger = Log.Logger.ForType<DataEncoder>();

    private readonly BinaryWriter _writer;
    private readonly OptionalMap _optionalMap;

    public DataEncoder(BinaryWriter writer) {
      _writer = writer;
      _optionalMap = new OptionalMap();
    }

    public DataEncoder(BinaryWriter writer, OptionalMap optionalMap) {
      _writer = writer;
      _optionalMap = optionalMap;
    }

    public void EncodePrimitive(object value) {
      Type writerType = _writer.GetType();
      Type valueType = value.GetType();

      MethodInfo? method = writerType.GetMethod("Write", new Type[] { valueType });
      if(method == null) throw new NotSupportedException($"Cannot encode type: {valueType.FullName}");

      method.Invoke(_writer, new object[] { value });
    }

    private void EncodeLength(int length) {
      switch(length) {
        case < 0: {
          throw new OverflowException($"Cannot encode length: {length}");
        }

        case < 0x80: {
          _writer.Write((byte)((uint)length & 0x7F));
          break;
        }

        case < 0x4000: {
          long num = (length & 0x3FFF) + 0x8000;
          _writer.Write((byte)((num & 0xFF00) >> 8));
          _writer.Write((byte)(num & 0xFF));
          break;
        }

        case < 0x400000: {
          long num2 = (length & 0x3FFFFF) + 0xC00000;
          _writer.Write((byte)((num2 & 0xFF0000) >> 16));
          _writer.Write((byte)((num2 & 0xFF00) >> 8));
          _writer.Write((byte)(num2 & 0xFF));
          break;
        }

        default: {
          throw new OverflowException($"Cannot encode length: {length}");
        }
      }
    }

    public void EncodeString(string value) {
      byte[] data = Encoding.UTF8.GetBytes(value);

      EncodeLength(data.Length);
      _writer.Write(data);
    }

    public async Task EncodeCollection<T>(ICollection<T> collection) {
      EncodeLength(collection.Count);
      // _writer.Write(collection.Count);

      foreach(T item in collection) {
        await SelectEncode(item);
      }
    }

    public void EncodeCommand(ICommand command) {
      Type commandType = command.GetType();

      _writer.Write(CommandUtils.GetCommandCode(commandType));
    }

    public void EncodeEnum<T>(T value) where T : Enum {
      switch(value.GetTypeCode()) {
        case TypeCode.Byte: {
          _writer.Write(Convert.ToByte(value));
          break;
        }

        default: {
          throw new ArgumentException($"Unsupported enum type: {value.GetTypeCode()}", nameof(value));
        }
      }
    }

    public void EncodeDateTime(DateTime time) {
      _writer.Write((new DateTimeOffset(time).UtcTicks - DateTime.UnixEpoch.Ticks) / TimeSpan.TicksPerMillisecond);
    }

    public void EncodeVector3(Vector3 vector) {
      _writer.Write(vector.X);
      _writer.Write(vector.Y);
      _writer.Write(vector.Z);
    }

    public void EncodeMoveCommand(MoveCommand command) {
      bool hasMovement = command.Movement != null;
      bool hasWeaponRotation = command.WeaponRotation != null;
      bool isDiscrete = command.IsDiscrete;

      _optionalMap.Add(hasMovement);
      _optionalMap.Add(hasWeaponRotation);
      _optionalMap.Add(isDiscrete);

      if(isDiscrete) {
        DiscreteTankControl control = new DiscreteTankControl() {
          MoveAxis = (int)command.TankControlVertical,
          TurnAxis = (int)command.TankControlHorizontal,
          WeaponControl = (int)command.WeaponRotationControl
        };

        _writer.Write(control.Control);
      } else {
        _writer.Write(command.TankControlVertical);
        _writer.Write(command.TankControlHorizontal);
        _writer.Write(command.WeaponRotationControl);
      }

      if(hasMovement) {
        MovementCodec.Encode(_writer, command.Movement!.Value);
      }

      if(hasWeaponRotation) {
        byte[] weaponRotationBuffer = new byte[CommandUtils.WeaponRotationSize];
        BitArray weaponRotation = new BitArray(weaponRotationBuffer);

        int position = 0;

        AbstractMoveCodec.WriteFloat(
          weaponRotation, ref position, command.WeaponRotation!.Value,
          CommandUtils.WeaponRotationComponentBitsize, CommandUtils.WeaponRotationFactor
        );
        weaponRotation.CopyTo(weaponRotationBuffer, 0);
        _writer.Write(weaponRotationBuffer);

        if(position != weaponRotation.Length) throw new InvalidOperationException("MoveCommand encode mismatch");
      }

      _writer.Write(command.ClientTime);
    }

    public void EncodeType(Type type) {
      _writer.Write(TypeUidUtils.GetId(type));
    }

    private async Task SelectEncode(object? value) {
      Type valueType = value.GetType();

      if(valueType.IsPrimitive || valueType == typeof(decimal)) {
        EncodePrimitive(value);
        return;
      }

      switch(value) {
        case string str:
          EncodeString(str);
          return;
        case Entity entity:
          EncodeEntity(entity);
          return;
        case IEntityTemplate _:
          EncodeType(valueType);
          return;
        case ICollection collection:
          await EncodeCollection((ICollection<object>)collection);
          return;
        case ICommand command:
          EncodeCommand(command);
          break;
        case Enum @enum:
          EncodeEnum(@enum);
          return;
        case DateTime date:
          EncodeDateTime(date);
          return;
        case Vector3 vector3:
          EncodeVector3(vector3);
          return;
        case Movement movement:
          MovementCodec.Encode(_writer, movement);
          return;
        case MoveCommand moveCommand:
          EncodeMoveCommand(moveCommand);
          return;
        case Type type:
          EncodeType(type);
          return;
      }

      if(valueType.IsGenericType) {
        if(valueType.GetGenericTypeDefinition() == typeof(ICollection<>)) {
          await (Task)this.CallMethod(
            valueType.GetGenericArguments(),
            "EncodeCollection",
            BindingFlags.NonPublic | BindingFlags.Instance
          );
          return;
        }

        if(valueType.GetGenericTypeDefinition() == typeof(HashSet<>)) {
          this.CallMethod(
            valueType.GetGenericArguments(),
            "EncodeHashSet",
            BindingFlags.NonPublic | BindingFlags.Instance
          );
          return;
        }
      }

      if(Attribute.IsDefined(valueType, typeof(TypeUidAttribute))) {
        EncodeType(valueType);
      }

      await EncodeObject(value);
    }

    public void EncodeEntity(Entity entity) {
      _writer.Write(entity.Id);
    }

    public async Task EncodeObject(object instance) {
      Type type = instance.GetType();

      foreach(PropertyInfo property in CommandUtils.GetProtocolProperties(type)) {
        object? value = property.GetValue(instance);

        bool isNull = value == null;
        bool isOptional = Attribute.IsDefined(property, typeof(ProtocolOptionalAttribute));

        if(isOptional) {
          _optionalMap.Add(isNull);
          if(isNull) continue;
        } else {
          if(isNull) throw new NullValueException(property);
        }

        await SelectEncode(value);
      }
    }

    public async Task EncodeCommands(IEnumerable<ICommand> commands) {
      await using MemoryStream stream = new MemoryStream();
      await using BinaryWriter commandsWriter = new BigEndianBinaryWriter(stream);

      OptionalMap optionalMap = new OptionalMap();
      DataEncoder encoder = new DataEncoder(commandsWriter, optionalMap);

      foreach(ICommand command in commands) {
        Logger.Verbose("Encoding command {Command}...", command);

        await encoder.SelectEncode(command);
      }

      commandsWriter.Flush();

      _writer.Write(CommandUtils.PacketHeader);
      _writer.Write(optionalMap.Length);
      _writer.Write((uint)commandsWriter.BaseStream.Length);
      _writer.Write(optionalMap.GetBytes());

      commandsWriter.BaseStream.Rewind();
      await commandsWriter.BaseStream.CopyToAsync(_writer.BaseStream);
    }
  }
}
