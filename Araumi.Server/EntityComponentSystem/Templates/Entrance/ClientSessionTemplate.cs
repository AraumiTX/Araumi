using Araumi.Server.EntityComponentSystem.Components.Entrance;
using Araumi.Server.EntityComponentSystem.Core;
using Araumi.Server.Protocol.Attributes;

namespace Araumi.Server.EntityComponentSystem.Templates.Entrance {
  [TypeUid(1429771189777)]
  public class ClientSessionTemplate : IEntityTemplate {
    public static Entity CreateEntity(string publicKey) {
      return new Entity(
        new TemplateAccessor(new ClientSessionTemplate(), null),
        new ClientSessionComponent(),
        new SessionSecurityPublicComponent(publicKey)
      );
    }
  }
}
