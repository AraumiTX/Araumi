using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Weapon {
  [TypeUid(1432792458422)]
  public class WeaponRotationComponent : Component {
    public float BaseSpeed { get; set; }
    public float Speed { get; set; }

    public float Acceleration { get; set; }

    // TODO(Assasans)
    public WeaponRotationComponent(float simplifiedTurretRotation) {
      BaseSpeed = simplifiedTurretRotation;
      Speed = simplifiedTurretRotation;

      Acceleration = simplifiedTurretRotation;
    }

    // TODO(Assasans)
    // public void ChangeByTemperature(BattleWeapon battleWeapon, float multiplier) {
    //   Speed = battleWeapon.OriginalWeaponRotationComponent.Speed * multiplier;
    // }
  }
}
