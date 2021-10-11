using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Effect.Unit {
  [TypeUid(1486455226183L)]
  public class UnitTargetComponent : Component {
    public Entity Target { get; set; }
    public Entity TargetIncarnation { get; set; }

    public UnitTargetComponent(Entity target, Entity targetIncarnation) {
      Target = target;
      TargetIncarnation = targetIncarnation;
    }
  }
}
