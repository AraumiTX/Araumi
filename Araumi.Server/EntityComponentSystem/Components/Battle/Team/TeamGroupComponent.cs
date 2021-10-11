using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;
using Araumi.Server.EntityComponentSystem.Components.Groups;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Team {
  [TypeUid(6955808089218759626)]
  public class TeamGroupComponent : GroupComponent {
    public TeamGroupComponent(Entity entity) : base(entity) { }
    public TeamGroupComponent(long key) : base(key) { }
  }
}
