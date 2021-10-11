using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Module {
  [TypeUid(1505906670608L)]
  public class ForceFieldTransformComponent : Component {
    public Movement.Movement Movement { get; set; }

    public ForceFieldTransformComponent(Movement.Movement movement) {
      Movement = movement;
    }
  }
}
