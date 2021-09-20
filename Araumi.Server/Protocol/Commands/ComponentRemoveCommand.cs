using System;
using System.Linq;
using System.Threading.Tasks;

using Araumi.Server.EntityComponentSystem.Core;
using Araumi.Server.Protocol.Attributes;
using Araumi.Server.Services.Servers.Game;

namespace Araumi.Server.Protocol.Commands {
  [CommandCode(5)]
  public class ComponentRemoveCommand : ICommand {
    [ProtocolFixed(0)] public Entity Entity { get; set; }
    [ProtocolFixed(1)] public Type ComponentType { get; set; }

    public ComponentRemoveCommand(Entity entity, Type componentType) {
      Entity = entity ?? throw new ArgumentNullException(nameof(entity));
      ComponentType = componentType ?? throw new ArgumentNullException(nameof(componentType));
    }

    public async Task OnReceive(Player player) {
      Component component = Entity.Components.Single(c => c.GetType() == ComponentType);
      Entity.RemoveComponent(ComponentType, player);

      await component.OnRemove(player, Entity);
    }

    public override string ToString() {
      return $"ComponentRemoveCommand [Entity: {Entity}, Component: {ComponentType}]";
    }
  }
}
