using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Weapon {
  [TypeUid(7115193786389139467)]
  public class WeaponCooldownComponent : Component {
    public float CooldownIntervalSec { get; set; }

    public WeaponCooldownComponent(float cooldownIntervalSec) {
      CooldownIntervalSec = cooldownIntervalSec;
    }
  }
}
