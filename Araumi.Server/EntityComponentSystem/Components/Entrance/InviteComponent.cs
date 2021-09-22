using Araumi.Server.EntityComponentSystem.Core;
using Araumi.Server.Protocol.Attributes;

namespace Araumi.Server.EntityComponentSystem.Components.Entrance {
  [TypeUid(1439808320725L)]
  public class InviteComponent: Component {
    public bool ShowScreenOnEntrance { get; set; }
    public string InviteCode { get; set; }

    public InviteComponent(bool showScreenOnEntrance, string inviteCode) {
      ShowScreenOnEntrance = showScreenOnEntrance;
      InviteCode = inviteCode;
    }
  }
}
