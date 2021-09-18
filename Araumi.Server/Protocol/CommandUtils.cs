using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Araumi.Server.Extensions;
using Araumi.Server.Protocol.Attributes;

using Serilog;

namespace Araumi.Server.Protocol {
  public static class CommandUtils {
    private static readonly ILogger Logger = Log.Logger.ForType(typeof(CommandUtils));

    public static readonly byte[] PacketHeader = new byte[] { 0xff, 0x00 };
    public static readonly byte[] HttpGetHeader = new byte[] { 0x47, 0x45, 0x54, 0x20 };

    public const int WeaponRotationSize = 2;
    public const int WeaponRotationComponentBitsize = WeaponRotationSize * 8;
    public const float WeaponRotationFactor = 360f / (1 << WeaponRotationComponentBitsize);

    private static readonly Dictionary<Type, byte> CommandToCodes = new Dictionary<Type, byte>();
    private static readonly Dictionary<byte, Type> CodeToCommands = new Dictionary<byte, Type>();

    private static readonly Dictionary<Type, List<PropertyInfo>> ProtocolProperties = new Dictionary<Type, List<PropertyInfo>>();

    static CommandUtils() {
      foreach(Type type in Assembly.GetExecutingAssembly().GetTypes()) {
        CommandCodeAttribute? attribute = type.GetCustomAttribute<CommandCodeAttribute>();
        if(attribute == null) continue;

        byte code = attribute.Code;

        CommandToCodes.Add(type, code);
        CodeToCommands.Add(code, type);
      }
    }

    public static byte GetCommandCode(Type type) {
      if(CommandToCodes.TryGetValue(type, out byte code)) return code;
      throw new ArgumentException($"Command code is not defined for type {type.FullName}", nameof(type));
    }

    public static Type GetCommandType(byte code) {
      if(CodeToCommands.TryGetValue(code, out Type? type)) return type;
      throw new ArgumentException($"Command with code {code} is not defined", nameof(code));
    }

    public static List<PropertyInfo> GetProtocolProperties(Type type) {
      if(!ProtocolProperties.TryGetValue(type, out List<PropertyInfo>? properties)) {
        properties = type.GetProperties()
          .Where((property) => !Attribute.IsDefined(property, typeof(ProtocolIgnoreAttribute)))
          .OrderBy((property) => property.GetCustomAttribute<ProtocolFixedAttribute>()?.Position)
          .ThenBy((property) => property.GetCustomAttribute<ProtocolNameAttribute>()?.Name ?? property.Name)
          .ToList();
        ProtocolProperties.Add(type, properties);

        // Logger.Verbose("Created new protocol properties list: {@Properties}", properties);
      } else {
        // Logger.Verbose("Using cached protocol properties list: {@Properties}", properties);
      }

      return properties;
    }
  }
}
