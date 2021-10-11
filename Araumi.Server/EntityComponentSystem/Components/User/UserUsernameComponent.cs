using Araumi.Server.EntityComponentSystem.Core;
using Araumi.Server.Protocol.Attributes;

namespace Araumi.Server.EntityComponentSystem.Components.User {
  /// <remarks>Original name: UserUidComponent</remarks>
  [TypeUid(-5477085396086342998)]
  public class UserUsernameComponent : Component {
    [ProtocolName("Uid")] public string Username { get; set; }

    public UserUsernameComponent(string username) {
      Username = username;
    }
  }
}
