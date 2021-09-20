using System;

namespace Araumi.Server.Protocol.Attributes {
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
  public sealed class TypeUidAttribute : Attribute {
    public long Id { get; }

    public TypeUidAttribute(long id) {
      Id = id;
    }
  }
}
