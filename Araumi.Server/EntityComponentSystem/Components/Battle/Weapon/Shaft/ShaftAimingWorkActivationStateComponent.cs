using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Weapon.Shaft {
  [TypeUid(8631717637564140236L)]
  public class ShaftAimingWorkActivationStateComponent : Component {
    public float ActivationTimer { get; set; }
    public int ClientTime { get; set; }
  }
}
