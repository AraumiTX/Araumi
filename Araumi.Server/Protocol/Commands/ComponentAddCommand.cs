using System.Threading.Tasks;

using Araumi.Server.EntityComponentSystem.Core;
using Araumi.Server.Protocol.Attributes;
using Araumi.Server.Services.Servers.Game;

namespace Araumi.Server.Protocol.Commands {
  [CommandCode(4)]
  public class ComponentAddCommand : ICommand {
    [ProtocolFixed(0)] public Entity Entity { get; set; }
    [ProtocolFixed(1)] public Component Component { get; set; }

    public ComponentAddCommand(Entity entity, Component component) {
      Entity = entity;
      Component = component;
    }

    public async Task OnReceive(Player player) {
      Entity.AddComponent(Component, player);

      await Component.OnAttach(player, Entity);
    }

    public override string ToString() {
      return $"ComponentAddCommand [Entity: {Entity}, Component: {Component}]";
    }
  }
}
