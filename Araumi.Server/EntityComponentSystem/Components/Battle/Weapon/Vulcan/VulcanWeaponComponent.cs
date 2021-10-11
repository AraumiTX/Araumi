using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Weapon.Vulcan {
  [TypeUid(4207390770640273134L)]
  // TODO(Assasans): Document
  public class VulcanWeaponComponent : Component {
    public float SpeedUpTime { get; set; }
    public float SlowDownTime { get; set; }
    public float TemperatureIncreasePerSec { get; set; }
    public float TemperatureLimit { get; set; }
    public float TemperatureHittingTime { get; set; }
    public float WeaponTurnDecelerationCoeff { get; set; }
    public float TargetHeatingMult { get; set; }

    public VulcanWeaponComponent(
      float speedUpTime, float slowDownTime,
      float temperatureIncreasePerSec, float temperatureLimit,
      float temperatureHittingTime, float weaponTurnDecelerationCoeff,
      float targetHeatingMult
    ) {
      SpeedUpTime = speedUpTime;
      SlowDownTime = slowDownTime;
      TemperatureIncreasePerSec = temperatureIncreasePerSec;
      TemperatureLimit = temperatureLimit;
      TemperatureHittingTime = temperatureHittingTime;
      WeaponTurnDecelerationCoeff = weaponTurnDecelerationCoeff;
      TargetHeatingMult = targetHeatingMult;
    }
  }
}
