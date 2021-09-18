using Araumi.Server.EntityComponentSystem.Core;
using Araumi.Server.Protocol.Attributes;

namespace Araumi.Server.EntityComponentSystem.Components.Entrance {
  [TypeUid(1439792100478)]
  public class SessionSecurityPublicComponent : Component {
    public string PublicKey { get; set; }

    public SessionSecurityPublicComponent(string publicKey) {
      PublicKey = publicKey;
    }
  }
}
