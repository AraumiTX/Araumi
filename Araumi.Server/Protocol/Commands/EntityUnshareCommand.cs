using System;
using System.Threading.Tasks;

using Araumi.Server.EntityComponentSystem.Core;
using Araumi.Server.Protocol.Attributes;
using Araumi.Server.Services.Servers.Game;

namespace Araumi.Server.Protocol.Commands {
	[CommandCode(3)]
	public class EntityUnshareCommand : ICommand {
		[ProtocolIgnore] public Entity Entity { get; }

		public EntityUnshareCommand(Entity entity) {
			Entity = entity ?? throw new ArgumentNullException(nameof(entity));
		}

		public async Task OnReceive(Player player) {
			throw new NotSupportedException("Client by itself cannot share entities.");
		}

		public override string ToString() => $"EntityUnshareCommand [Entity: {Entity}]";
	}
}
