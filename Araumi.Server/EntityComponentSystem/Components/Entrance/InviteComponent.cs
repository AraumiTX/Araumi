using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Entrance {
  [TypeUid(1439808320725)]
  public class InviteComponent : Component {
    [ProtocolName("ShowScreenOnEntrance")] public bool ShowOnEntrance { get; set; }
    [ProtocolOptional] public string? InviteCode { get; set; }

    public InviteComponent(string? inviteCode = null, bool showOnEntrance = true) {
      ShowOnEntrance = showOnEntrance;
      InviteCode = inviteCode;
    }
  }
}
