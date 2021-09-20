using System;

namespace Araumi.Server.Protocol.Attributes {
  [AttributeUsage(AttributeTargets.Property)]
  public sealed class ProtocolIgnoreAttribute : Attribute {
    public ProtocolIgnoreAttribute() { }
  }
}
