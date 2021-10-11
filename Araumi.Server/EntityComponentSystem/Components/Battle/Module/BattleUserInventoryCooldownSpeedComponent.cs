using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Module {
  [TypeUid(636366605665347423L)]
  public class BattleUserInventoryCooldownSpeedComponent : Component {
    public float SpeedCoeff { get; set; }

    public BattleUserInventoryCooldownSpeedComponent(float speedCoeff) {
      SpeedCoeff = speedCoeff;
    }
  }
}
