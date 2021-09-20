using System.Threading.Tasks;

using Araumi.Server.EntityComponentSystem.Core;
using Araumi.Server.Protocol.Attributes;
using Araumi.Server.Services.Servers.Game;

namespace Araumi.Server.Protocol.Commands {
  [CommandCode(6)]
  public class ComponentChangeCommand : ICommand {
    [ProtocolFixed(0)] public Entity Entity { get; set; }
    [ProtocolFixed(1)] public Component Component { get; set; }

    public ComponentChangeCommand(Entity entity, Component component) {
      Entity = entity;
      Component = component;
    }

    public async Task OnReceive(Player player) {
      Entity.ChangeComponent(Component, player);

      await Component.OnRemove(player, Entity);
    }

    public override string ToString() {
      return $"ComponentChangeCommand [Entity: {Entity}, Component: {Component}]";
    }
  }
}
