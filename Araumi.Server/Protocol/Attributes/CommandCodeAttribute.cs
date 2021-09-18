using System;

namespace Araumi.Server.Protocol.Attributes {
	[AttributeUsage(AttributeTargets.Class)]
	public sealed class CommandCodeAttribute : Attribute {
		public byte Code { get; }

		public CommandCodeAttribute(byte code) {
			Code = code;
		}
	}
}
