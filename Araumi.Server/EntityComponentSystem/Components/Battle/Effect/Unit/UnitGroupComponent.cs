using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;
using Araumi.Server.EntityComponentSystem.Components.Groups;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Effect.Unit {
  [TypeUid(1485231135123L)]
  public class UnitGroupComponent : GroupComponent {
    public UnitGroupComponent(Entity entity) : base(entity) { }
    public UnitGroupComponent(long key) : base(key) { }
  }
}
