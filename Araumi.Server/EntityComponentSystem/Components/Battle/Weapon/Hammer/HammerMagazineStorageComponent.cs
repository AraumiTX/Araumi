using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Weapon.Hammer {
  /// <remarks>Original name: MagazineStorageComponent</remarks>
  [TypeUid(2388237143993578319L)]
  public class HammerMagazineStorageComponent : Component {
    public int CurrentCartridgeCount { get; set; }

    public HammerMagazineStorageComponent(int currentCartridgeCount) {
      CurrentCartridgeCount = currentCartridgeCount;
    }
  }
}
