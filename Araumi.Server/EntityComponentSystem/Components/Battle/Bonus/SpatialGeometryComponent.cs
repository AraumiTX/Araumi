using System.Numerics;

using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Bonus {
  [TypeUid(8960819779144518L)]
  public class SpatialGeometryComponent : Component {
    public Vector3 Position { get; set; }
    public Vector3 Rotation { get; set; }

    public SpatialGeometryComponent(Vector3 position, Vector3 rotation) {
      Position = position;
      Rotation = rotation;
    }
  }
}
