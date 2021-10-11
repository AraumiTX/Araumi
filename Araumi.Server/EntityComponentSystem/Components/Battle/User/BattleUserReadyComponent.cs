using System;

using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;
using Araumi.Server.EntityComponentSystem.Types.Battle.Tank;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.User {
  /// <remarks>Original name: UserReadyToBattleComponent</remarks>
  [TypeUid(1399558738794728790)]
  public class BattleUserReadyComponent : Component {
    public void OnAttached(Services.Servers.Game.Player player, Entity battleUser) {
      throw new NotImplementedException();
      // if(player.BattlePlayer != null) player.BattlePlayer.MatchPlayer.TankState = TankState.Spawn;
    }
  }
}
