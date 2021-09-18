using Araumi.Server.EntityComponentSystem.Core;
using Araumi.Server.Protocol.Attributes;

namespace Araumi.Server.EntityComponentSystem.Components.Entrance {
  [TypeUid(1479820450460)]
  public class WebIdComponent : Component {
    public string WebId { get; set; } = "";
    public string Utm { get; set; } = "";
    public string GoogleAnalyticsId { get; set; } = "";
    public string WebIdUid { get; set; } = "";
  }
}
