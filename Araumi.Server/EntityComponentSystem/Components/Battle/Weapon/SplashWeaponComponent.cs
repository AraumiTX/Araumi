using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Weapon {
  [TypeUid(3169143415222756957L)]
  // TODO(Assasans): Document
  public class SplashWeaponComponent : Component {
    public float MinSplashDamagePercent { get; set; }

    public float RadiusOfMaxSplashDamage { get; set; }
    public float RadiusOfMinSplashDamage { get; set; }

    public SplashWeaponComponent(float minSplashDamagePercent, float radiusOfMaxSplashDamage, float radiusOfMinSplashDamage) {
      MinSplashDamagePercent = minSplashDamagePercent;
      RadiusOfMaxSplashDamage = radiusOfMaxSplashDamage;
      RadiusOfMinSplashDamage = radiusOfMinSplashDamage;
    }
  }
}
