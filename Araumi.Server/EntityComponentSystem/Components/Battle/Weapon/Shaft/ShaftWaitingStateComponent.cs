using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Weapon.Shaft {
  [TypeUid(6541712051864507498L)]
  public class ShaftWaitingStateComponent : Component {
    public float WaitingTimer { get; set; }
    public int Time { get; set; }
  }
}
