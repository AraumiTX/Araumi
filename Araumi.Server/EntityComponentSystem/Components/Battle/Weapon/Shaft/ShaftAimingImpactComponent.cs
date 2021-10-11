using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Weapon.Shaft {
  [TypeUid(1437983715951L)]
  public class ShaftAimingImpactComponent : Component {
    public float MaxImpactForce { get; set; }

    public ShaftAimingImpactComponent(float maxImpactForce) {
      MaxImpactForce = maxImpactForce;
    }
  }
}
