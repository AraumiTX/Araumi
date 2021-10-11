using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Weapon.Shaft {
  [TypeUid(1826384779893027508L)]
  public class ShaftEnergyComponent : Component {
    public float UnloadEnergyPerQuickShot { get; set; }
    public float PossibleUnloadEnergyPerAimingShot { get; set; }

    public float UnloadAimingEnergyPerSec { get; set; }
    public float ReloadEnergyPerSec { get; set; }

    public ShaftEnergyComponent(
      float unloadEnergyPerQuickShot, float possibleUnloadEnergyPerAimingShot,
      float unloadAimingEnergyPerSec, float reloadEnergyPerSec
    ) {
      UnloadEnergyPerQuickShot = unloadEnergyPerQuickShot;
      PossibleUnloadEnergyPerAimingShot = possibleUnloadEnergyPerAimingShot;

      UnloadAimingEnergyPerSec = unloadAimingEnergyPerSec;
      ReloadEnergyPerSec = reloadEnergyPerSec;
    }
  }
}
