using System.Numerics;

using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Graffiti {
  [TypeUid(636100801609006236L)]
  public class GraffitiDecalComponent : Component {
    public Vector3 SprayPosition { get; set; }
    public Vector3 SprayDirection { get; set; }
    public Vector3 SprayUpDirection { get; set; }
  }
}
