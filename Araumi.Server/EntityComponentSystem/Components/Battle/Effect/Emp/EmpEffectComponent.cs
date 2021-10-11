using Araumi.Server.EntityComponentSystem.Core;
using Araumi.Server.Protocol.Attributes;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Effect.Emp {
  /// <remarks>Original name: EMPEffectComponent</remarks>
  [TypeUid(636250000933021510L)]
  public class EmpEffectComponent : Component {
    public float Radius { get; set; }

    public EmpEffectComponent(float radius) {
      Radius = radius;
    }
  }
}
