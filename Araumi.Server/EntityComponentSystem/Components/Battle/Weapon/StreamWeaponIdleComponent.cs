using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Weapon {
  [TypeUid(1498352458940656986L)]
  public class StreamWeaponIdleComponent : Component {
    public int Time { get; set; }
  }
}
