using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Chassis {
  [TypeUid(-1745565482362521070)]
  public class SpeedComponent : Component {
    public float Speed { get; set; }
    public float TurnSpeed { get; set; }
    public float Acceleration { get; set; }

    public SpeedComponent(float speed, float turnSpeed, float acceleration) {
      Speed = speed;
      TurnSpeed = turnSpeed;
      Acceleration = acceleration;
    }
  }
}
