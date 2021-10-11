using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Tank {
  [TypeUid(5166099393636831290)]
  public class TankSemiActiveStateComponent : Component {
    public float ActivationTime { get; set; }

    public TankSemiActiveStateComponent(float activationTime = 0.25f) {
      ActivationTime = activationTime;
    }
  }
}
