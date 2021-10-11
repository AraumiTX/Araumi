using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Weapon {
  [TypeUid(1438773081827L)]
  public class SplashImpactComponent : Component {
    public SplashImpactComponent(float impactForce) {
      ImpactForce = impactForce;
    }

    public float ImpactForce { get; set; }
  }
}
