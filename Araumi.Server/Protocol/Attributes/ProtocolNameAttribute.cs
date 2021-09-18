using System;

namespace Araumi.Server.Protocol.Attributes {
	[AttributeUsage(AttributeTargets.Property)]
	public sealed class ProtocolNameAttribute : Attribute {
		public string Name { get; }

		public ProtocolNameAttribute(string name) {
      Name = name;
    }
	}
}
