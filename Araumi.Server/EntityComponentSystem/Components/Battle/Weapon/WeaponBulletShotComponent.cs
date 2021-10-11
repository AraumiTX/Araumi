using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Weapon {
  [TypeUid(1438152738643L)]
  public class WeaponBulletShotComponent : Component {
    public float BulletRadius { get; set; }
    public float BulletSpeed { get; set; }

    public WeaponBulletShotComponent(float bulletRadius, float bulletSpeed) {
      BulletRadius = bulletRadius;
      BulletSpeed = bulletSpeed;
    }
  }
}
