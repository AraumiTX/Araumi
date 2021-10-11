using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Weapon.Railgun {
  [TypeUid(2654416098660377118L)]
  public class RailgunChargingWeaponComponent : Component {
    public float ChargingTime { get; set; }

    public RailgunChargingWeaponComponent(float chargingTime) {
      ChargingTime = chargingTime;
    }
  }
}
