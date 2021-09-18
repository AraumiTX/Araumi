using YamlDotNet.Serialization;

namespace Araumi.Server.Services.Servers.Static.Models {
	public class StateConfig {
		[YamlMember(Alias = "state")] public int State { get; set; }
	}
}
