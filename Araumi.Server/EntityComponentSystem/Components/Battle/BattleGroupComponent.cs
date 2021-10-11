using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;
using Araumi.Server.EntityComponentSystem.Components.Groups;

namespace Araumi.Server.EntityComponentSystem.Components.Battle {
  [TypeUid(1140613249019529884)]
  public class BattleGroupComponent : GroupComponent {
    public BattleGroupComponent(Entity entity) : base(entity) { }
    public BattleGroupComponent(long key) : base(key) { }
  }
}
