using System;
using System.Runtime.Serialization;

namespace Araumi.Server.Protocol.Exceptions {
  public abstract class TypeUidException : Exception {
    public TypeUidException() { }
    public TypeUidException(string? message) : base(message) { }
    public TypeUidException(string? message, Exception? innerException) : base(message, innerException) { }

    protected TypeUidException(SerializationInfo info, StreamingContext context) : base(info, context) { }
  }
}
