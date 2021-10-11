using System.Numerics;

using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Bonus {
  /// <remarks>Original name: PositionComponent</remarks>
  [TypeUid(4605414188335188027)]
  public class BonusPositionComponent : Component {
    public Vector3 Position { get; set; }

    public BonusPositionComponent(Vector3 position) {
      Position = position;
    }
  }
}
