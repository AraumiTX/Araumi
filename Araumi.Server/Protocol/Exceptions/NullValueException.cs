using System;
using System.Reflection;

using Araumi.Server.Protocol.Attributes;

namespace Araumi.Server.Protocol.Exceptions {
  public class NullValueException : Exception {
    public MemberInfo Member { get; }

    public override string Message =>
      $"Member {Member.DeclaringType?.Name}.{Member.Name} is null, but does not have {nameof(ProtocolOptionalAttribute)}";

    public NullValueException(MemberInfo member, Exception? innerException = null) : base(null, innerException) {
      Member = member;
    }
  }
}
