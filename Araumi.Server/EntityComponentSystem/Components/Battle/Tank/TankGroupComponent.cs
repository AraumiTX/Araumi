using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;
using Araumi.Server.EntityComponentSystem.Components.Groups;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Tank {
  [TypeUid(4088029591333632383)]
  public class TankGroupComponent : GroupComponent {
    public TankGroupComponent(Entity entity) : base(entity) { }
    public TankGroupComponent(long key) : base(key) { }
  }
}
