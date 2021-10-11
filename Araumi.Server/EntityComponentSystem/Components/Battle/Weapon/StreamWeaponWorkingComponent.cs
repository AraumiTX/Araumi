using System;

using Araumi.Server.Protocol.Attributes;
using Araumi.Server.Services.Servers.Game;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Weapon {
  [TypeUid(971549724137995758L)]
  public class StreamWeaponWorkingComponent : Component {
    public int Time { get; set; }

    public void OnAttached(Services.Servers.Game.Player player, Entity battleUser) {
      throw new NotImplementedException();
      // player.BattlePlayer.MatchPlayer.TryDeactivateInvisibility();
    }

    public void OnRemove(Services.Servers.Game.Player player, Entity battleUser) {
      throw new NotImplementedException();
      // player.BattlePlayer.MatchPlayer.StreamHitLengths.Clear();
    }
  }
}
