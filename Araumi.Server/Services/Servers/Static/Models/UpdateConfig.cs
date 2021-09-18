using System;

using YamlDotNet.Serialization;

namespace Araumi.Server.Services.Servers.Static.Models {
	public class UpdateConfig {
		[YamlMember(typeof(string), Alias = "distributionUrl")] public Uri DistributionUri { get; set; } = null!;
		[YamlMember(Alias = "executable")] public string Executable { get; set; } = null!;

		[YamlMember(Alias = "lastClientVersion")] public string ClientVersion { get; set; } = null!;
	}
}
