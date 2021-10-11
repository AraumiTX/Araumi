using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.User {
  /// <remarks>Original name: UserInBattleAsSpectatorComponent</remarks>
  [TypeUid(4788927540455272293)]
  public class BattleUserAsSpectatorComponent : Component {
    public long BattleId { get; set; }

    public BattleUserAsSpectatorComponent(long battleId) {
      BattleId = battleId;
    }
  }
}
