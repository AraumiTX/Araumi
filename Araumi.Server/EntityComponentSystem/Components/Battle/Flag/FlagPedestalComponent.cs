using System.Numerics;

using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Flag {
  [TypeUid(4898317045808451550L)]
  public class FlagPedestalComponent : Component {
    public Vector3 Position { get; set; }

    public FlagPedestalComponent(Vector3 position) {
      Position = position;
    }
  }
}
