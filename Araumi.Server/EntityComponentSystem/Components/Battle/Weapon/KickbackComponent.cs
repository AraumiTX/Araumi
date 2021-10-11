using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Weapon {
  [TypeUid(1437989437781L)]
  public class KickbackComponent : Component {
    public float KickbackForce { get; set; }

    public KickbackComponent(float kickbackForce) {
      KickbackForce = kickbackForce;
    }
  }
}
