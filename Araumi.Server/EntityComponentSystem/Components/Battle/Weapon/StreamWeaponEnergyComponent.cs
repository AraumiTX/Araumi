using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Weapon {
  [TypeUid(1438077278464L)]
  public class StreamWeaponEnergyComponent : Component {
    public float UnloadEnergyPerSec { get; set; }
    public float ReloadEnergyPerSec { get; set; }

    // TODO(Assasans): Check uses, changed parameter order (1 and 2)
    public StreamWeaponEnergyComponent(float unloadEnergyPerSec, float reloadEnergyPerSec) {
      UnloadEnergyPerSec = unloadEnergyPerSec;
      ReloadEnergyPerSec = reloadEnergyPerSec;
    }
  }
}
