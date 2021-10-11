using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Weapon {
  [TypeUid(1438077188268L)]
  public class DiscreteWeaponEnergyComponent : Component {
    public float ReloadEnergyPerSec { get; set; }
    public float UnloadEnergyPerShot { get; set; }

    public DiscreteWeaponEnergyComponent(float reloadEnergyPerSec, float unloadEnergyPerShot) {
      ReloadEnergyPerSec = reloadEnergyPerSec;
      UnloadEnergyPerShot = unloadEnergyPerShot;
    }
  }
}
