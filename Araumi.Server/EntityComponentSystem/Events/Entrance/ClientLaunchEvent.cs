using Araumi.Server.EntityComponentSystem.Components.Entrance;
using Araumi.Server.EntityComponentSystem.Core;
using Araumi.Server.Protocol.Attributes;
using Araumi.Server.Services.Servers.Game;

namespace Araumi.Server.EntityComponentSystem.Events.Entrance {
  [TypeUid(1478774431678)]
  public class ClientLaunchEvent : IEvent {
    public string WebId { get; set; } = null!;

    public void Execute(Player player, Entity clientSession) {
      clientSession.AddComponent(new WebIdComponent());
    }
  }
}
