using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Weapon.Vulcan {
  [TypeUid(-7317457627241247550L)]
  public class VulcanSpeedUpComponent : Component {
    public int ClientTime { get; set; }
  }
}
