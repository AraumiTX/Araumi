using System.Numerics;

using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Effect.Unit {
  [TypeUid(1485519196443L)]
  public class UnitMoveComponent : Component {
    public Movement.Movement Movement { get; set; }

    [ProtocolIgnore] public Vector3 LastPosition { get; set; }

    public UnitMoveComponent(Movement.Movement movement) {
      Movement = movement;
    }
  }
}
