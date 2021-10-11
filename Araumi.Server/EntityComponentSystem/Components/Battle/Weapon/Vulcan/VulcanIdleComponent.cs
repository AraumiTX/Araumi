using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Weapon.Vulcan {
  [TypeUid(-3791262141248621103L)]
  public class VulcanIdleComponent : Component {
    public int Time { get; set; }
  }
}
