using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Effect.SpiderMine {
  [TypeUid(1487227856805L)]
  public class SpiderMineConfigComponent : Component {
    public float Speed { get; set; }
    public float Acceleration { get; set; }

    public float Energy { get; set; }
    public float IdleEnergyDrainRate { get; set; }
    public float ChasingEnergyDrainRate { get; set; }

    public SpiderMineConfigComponent(float acceleration, float speed) {
      Speed = speed;
      Acceleration = acceleration;

      Energy = 100;
      IdleEnergyDrainRate = 0;
      ChasingEnergyDrainRate = 0;
    }
  }
}
