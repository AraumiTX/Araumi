using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Effect.Unit {
  [TypeUid(636364931473899150L)]
  public class UnitTargetingConfigComponent : Component {
    public float TargetingPeriod { get; set; }
    public float WorkDistance { get; set; }

    public UnitTargetingConfigComponent(float targetingPeriod, float workingDistance) {
      TargetingPeriod = targetingPeriod;
      WorkDistance = workingDistance;
    }
  }
}
