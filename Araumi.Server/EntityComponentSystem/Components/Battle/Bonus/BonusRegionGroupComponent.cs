using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;
using Araumi.Server.EntityComponentSystem.Components.Groups;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Bonus {
  [TypeUid(8566120830355322079L)]
  public class BonusRegionGroupComponent : GroupComponent {
    public BonusRegionGroupComponent(Entity entity) : base(entity) { }
    public BonusRegionGroupComponent(long key) : base(key) { }
  }
}
