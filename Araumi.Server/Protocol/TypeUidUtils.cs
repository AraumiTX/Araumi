using System;
using System.Collections.Generic;
using System.Reflection;

using Araumi.Server.Protocol.Attributes;
using Araumi.Server.Protocol.Exceptions;

namespace Araumi.Server.Protocol {
  public static class TypeUidUtils {
    private static readonly Dictionary<Type, long> _typeToIds = new Dictionary<Type, long>();
    private static readonly Dictionary<long, Type> _idToTypes = new Dictionary<long, Type>();

    static TypeUidUtils() {
      foreach(Type type in Assembly.GetExecutingAssembly().GetTypes()) {
        TypeUidAttribute? attribute = type.GetCustomAttribute<TypeUidAttribute>();
        if(attribute == null) continue;

        long id = attribute.Id;

        _typeToIds.Add(type, id);
        _idToTypes.Add(id, type);
      }
    }

    public static long GetId(Type type) {
      if(_typeToIds.TryGetValue(type, out long id)) return id;
      throw new MissingTypeUidException(type);
    }

    public static Type GetTypeById(long id) {
      if(_idToTypes.TryGetValue(id, out Type? type)) return type;
      throw new UnknownTypeUidException(id);
    }
  }
}
