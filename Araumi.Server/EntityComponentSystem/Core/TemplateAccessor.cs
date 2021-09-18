using Araumi.Server.Protocol.Attributes;

namespace Araumi.Server.EntityComponentSystem.Core {
	public class TemplateAccessor {
		[ProtocolFixed(0)] public IEntityTemplate Template { get; set; }
		[ProtocolFixed(1)] [ProtocolOptional] public string? ConfigPath { get; set; }

		public TemplateAccessor(IEntityTemplate template, string? configPath) {
			Template = template;
			ConfigPath = configPath;
		}

		public override string ToString() {
			return $"[{Template.GetType().Name}, \"{ConfigPath}\"]";
		}
	}
}
