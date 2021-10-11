using System.Numerics;

using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Effect.Mine {
  [TypeUid(1431673085710L)]
  public class MinePositionComponent : Component {
    public Vector3 Position { get; set; }

    public MinePositionComponent(Vector3 position) {
      Position = position;
    }
  }
}
