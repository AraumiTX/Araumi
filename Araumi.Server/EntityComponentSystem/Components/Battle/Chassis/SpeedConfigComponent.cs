using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Chassis {
  [TypeUid(-177474741853856725L)]
  public class SpeedConfigComponent : Component {
    public float ReverseAcceleration { get; set; }
    public float ReverseTurnAcceleration { get; set; }
    public float SideAcceleration { get; set; }
    public float TurnAcceleration { get; set; }

    public SpeedConfigComponent(float turnAcceleration, float sideAcceleration, float reverseAcceleration, float reverseTurnAcceleration) {
      ReverseAcceleration = reverseAcceleration;
      ReverseTurnAcceleration = reverseTurnAcceleration;
      SideAcceleration = sideAcceleration;
      TurnAcceleration = turnAcceleration;
    }
  }
}
