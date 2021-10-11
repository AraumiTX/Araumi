using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Weapon.Hammer {
  /// <remarks>Original name: MagazineWeaponComponent</remarks>
  [TypeUid(4355651182908057733L)]
  public class HammerMagazineWeaponComponent : Component {
    public int MaxCartridgeCount { get; set; }
    public float ReloadMagazineTimePerSec { get; set; }

    public HammerMagazineWeaponComponent(int maxCartridgeCount, float reloadMagazineTimePerSec) {
      MaxCartridgeCount = maxCartridgeCount;
      ReloadMagazineTimePerSec = reloadMagazineTimePerSec;
    }
  }
}
