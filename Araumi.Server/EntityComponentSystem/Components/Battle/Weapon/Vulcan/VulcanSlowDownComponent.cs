using System;

using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Weapon.Vulcan {
  [TypeUid(-6843896944033144903L)]
  public class VulcanSlowDownComponent : Component {
    public int ClientTime { get; set; }

    public bool IsAfterShooting { get; set; }

    public void OnAttached(Services.Servers.Game.Player player, Entity weapon) {
      if(!IsAfterShooting) return;

      throw new NotImplementedException();
      // ((Vulcan)player.BattlePlayer.MatchPlayer.BattleWeapon).LastVulcanHeatTactTime = null;
      // ((Vulcan)player.BattlePlayer.MatchPlayer.BattleWeapon).VulcanShootingStartTime = null;
    }
  }
}
