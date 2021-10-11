using System.Numerics;

using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Flag {
  [TypeUid(-7424433796811681217L)]
  public class FlagPositionComponent : Component {
    public Vector3 Position { get; set; }

    public FlagPositionComponent(Vector3 position) {
      Position = position;
    }
  }
}
