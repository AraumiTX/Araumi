using System;

namespace Araumi.Server.Protocol.Exceptions {
  public class MissingTypeUidException : TypeUidException {
    public Type Type { get; }

    public override string Message => $"TypeUid attribute is not defined for type {Type}";

    public MissingTypeUidException(Type type, Exception? innerException = null) : base(null, innerException) {
      Type = type;
    }
  }
}
