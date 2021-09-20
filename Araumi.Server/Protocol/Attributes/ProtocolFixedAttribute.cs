using System;

namespace Araumi.Server.Protocol.Attributes {
  [AttributeUsage(AttributeTargets.Property)]
  public sealed class ProtocolFixedAttribute : Attribute {
    public int Position { get; }

    public ProtocolFixedAttribute(int position) {
      Position = position;
    }
  }
}
