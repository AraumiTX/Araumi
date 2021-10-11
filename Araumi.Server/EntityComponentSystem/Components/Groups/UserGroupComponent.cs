using Araumi.Server.EntityComponentSystem.Core;
using Araumi.Server.Protocol.Attributes;

namespace Araumi.Server.EntityComponentSystem.Components.Groups {
  [TypeUid(7453043498913563889)]
  public class UserGroupComponent : GroupComponent {
    public UserGroupComponent(Entity entity) : base(entity) { }
    public UserGroupComponent(long key) : base(key) { }
  }
}
