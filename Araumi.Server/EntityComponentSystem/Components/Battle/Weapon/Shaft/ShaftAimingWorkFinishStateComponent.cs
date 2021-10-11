using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Weapon.Shaft {
  [TypeUid(-5670596162316552032L)]
  public class ShaftAimingWorkFinishStateComponent : Component {
    public float FinishTimer { get; set; }
    public int ClientTime { get; set; }
  }
}
