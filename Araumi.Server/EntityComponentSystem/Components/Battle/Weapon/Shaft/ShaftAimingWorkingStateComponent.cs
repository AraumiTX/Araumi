using System;
using System.Numerics;

using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Weapon.Shaft {
  [TypeUid(4186891190183470299L)]
  public class ShaftAimingWorkingStateComponent : Component {
    public float InitialEnergy { get; set; }
    public float ExhaustedEnergy { get; set; }
    public float VerticalAngle { get; set; }
    public Vector3 WorkingDirection { get; set; }
    public float VerticalSpeed { get; set; }
    public int VerticalElevationDir { get; set; }
    public bool IsActive { get; set; }
    public int ClientTime { get; set; }

    public void OnAttached(Services.Servers.Game.Player player, Entity weapon) {
      throw new NotImplementedException();
      // ((Shaft)player.BattlePlayer.MatchPlayer.BattleWeapon).StartAiming();
    }

    public void OnRemove(Services.Servers.Game.Player player, Entity weapon) {
      throw new NotImplementedException();
      // ((Shaft)player.BattlePlayer.MatchPlayer.BattleWeapon).StopAiming();
    }
  }
}
