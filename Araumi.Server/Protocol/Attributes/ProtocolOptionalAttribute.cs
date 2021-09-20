using System;

namespace Araumi.Server.Protocol.Attributes {
  [AttributeUsage(AttributeTargets.Property)]
  public sealed class ProtocolOptionalAttribute : Attribute {
    public ProtocolOptionalAttribute() { }
  }
}
