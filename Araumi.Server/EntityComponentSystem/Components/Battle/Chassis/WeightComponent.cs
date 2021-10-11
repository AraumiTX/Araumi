using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Chassis {
  [TypeUid(1437571863912)]
  public class WeightComponent : Component {
    public float Weight { get; set; }

    public WeightComponent(float weight) {
      Weight = weight;
    }
  }
}
