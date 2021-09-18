using System;

namespace Araumi.Server.Protocol.Exceptions {
  public class UnknownTypeUidException : Exception {
    public long TypeUid { get; }

    public override string Message => $"Type with TypeUid {TypeUid} not found";

    public UnknownTypeUidException(long typeUid, Exception? innerException = null) : base(null, innerException) {
      TypeUid = typeUid;
    }
  }
}
