using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Effect.ExplosiveMass {
  [TypeUid(1543402751411L)]
  public class ExplosiveMassEffectComponent : Component {
    public float Radius { get; set; }
    public long Delay { get; set; }

    public ExplosiveMassEffectComponent(float radius, long delay = 3000) {
      Radius = radius;
      Delay = delay;
    }
  }
}
