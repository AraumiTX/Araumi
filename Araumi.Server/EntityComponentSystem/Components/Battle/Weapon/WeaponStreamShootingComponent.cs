using System;

using Araumi.Server.Protocol.Attributes;
using Araumi.Server.Services.Servers.Game;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Weapon {
  [TypeUid(6803807621463709653L)]
  public class WeaponStreamShootingComponent : Component {
    [ProtocolOptional] public DateTime? StartShootingTime { get; set; }

    public int Time { get; set; }

    public void OnAttached(Services.Servers.Game.Player player, Entity weapon) {
      throw new NotImplementedException();
      // if(player.BattlePlayer.MatchPlayer.BattleWeapon.GetType() == typeof(Vulcan)) {
      //   ((Vulcan)player.BattlePlayer.MatchPlayer.BattleWeapon).TrySaveShootingStartTime();
      // }
    }
  }
}
