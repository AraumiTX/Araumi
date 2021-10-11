using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.User {
  [TypeUid(1545809085571L)]
  public class UserAvatarComponent : Component {
    public string Id { get; set; }

    public UserAvatarComponent(string id) {
      Id = id;
    }
  }
}
