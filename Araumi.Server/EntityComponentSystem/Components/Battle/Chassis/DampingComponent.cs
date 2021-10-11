using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Chassis {
  [TypeUid(1437725485852)]
  public class DampingComponent : Component {
    public float Damping { get; set; }

    public DampingComponent(float damping) {
      Damping = damping;
    }
  }
}
