using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Player {
  /// <remarks>Original name: UserEquipmentComponent</remarks>
  [TypeUid(1496906087610)]
  public class BattlePlayerEquipmentComponent : Component {
    public long WeaponId { get; set; }
    public long HullId { get; set; }

    public BattlePlayerEquipmentComponent(long weaponId, long hullId) {
      WeaponId = weaponId;
      HullId = hullId;
    }
  }
}
