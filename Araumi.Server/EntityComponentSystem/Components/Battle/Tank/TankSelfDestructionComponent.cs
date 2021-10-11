using System;

using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Tank {
  /// <remarks>Original name: SelfDestructionComponent</remarks>
  [TypeUid(-9188485263407476652L)]
  public class TankSelfDestructionComponent : Component {
    public void OnAttached(Services.Servers.Game.Player player, Entity tank) {
      throw new NotImplementedException();
      // player.BattlePlayer.MatchPlayer.SelfDestructionTime = DateTime.UtcNow.AddSeconds(5);
    }
  }
}
