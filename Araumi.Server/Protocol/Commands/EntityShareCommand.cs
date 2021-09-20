using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Araumi.Server.EntityComponentSystem.Core;
using Araumi.Server.Protocol.Attributes;
using Araumi.Server.Services.Servers.Game;

namespace Araumi.Server.Protocol.Commands {
  [CommandCode(2)]
  public class EntityShareCommand : ICommand {
    [ProtocolIgnore] public Entity Entity { get; }

    [ProtocolFixed(0)] public long EntityId { get; }
    [ProtocolFixed(1)] [ProtocolOptional] public TemplateAccessor? TemplateAccessor { get; }
    [ProtocolFixed(2)] public IReadOnlyCollection<Component> Components { get; }

    public EntityShareCommand(Entity entity, Player player) {
      Entity = entity ?? throw new ArgumentNullException(nameof(entity));

      EntityId = entity.Id;
      TemplateAccessor = entity.TemplateAccessor;

      Component[] shareAbleComponents = Entity.Components.Where(c => c.PlayerOnly is null || c.PlayerOnly == player).ToArray();

      Components = new Component[shareAbleComponents.Length];
      shareAbleComponents.CopyTo((Component[])Components, 0);
    }

    public async Task OnReceive(Player player) {
      throw new NotSupportedException();
    }

    public override string ToString() => $"EntityShareCommand [Entity: {Entity}]";
  }
}
