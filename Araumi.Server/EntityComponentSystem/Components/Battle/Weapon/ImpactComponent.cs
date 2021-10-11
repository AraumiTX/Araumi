using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Weapon {
  [TypeUid(1437983636148L)]
  public class ImpactComponent : Component {
    public float ImpactForce { get; set; }

    public ImpactComponent(float impactForce) {
      ImpactForce = impactForce;
    }
  }
}
