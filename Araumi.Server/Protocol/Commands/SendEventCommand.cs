using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Araumi.Server.EntityComponentSystem.Core;
using Araumi.Server.Protocol.Attributes;
using Araumi.Server.Services.Servers.Game;

namespace Araumi.Server.Protocol.Commands {
	[CommandCode(1)]
	public class SendEventCommand : ICommand {
		[ProtocolFixed(0)] public IEvent Event { get; set; }
		[ProtocolFixed(1)] public Entity[] Entities { get; set; }

		public SendEventCommand(IEvent @event, params Entity[] entities) {
			Event = @event;
			Entities = entities;
		}

		/// <summary>
		/// Finds event method with same number of Entity parameters and calls it.
		/// </summary>
		public async Task OnReceive(Player player) {
			bool canBeExecuted = false;

			foreach(MethodInfo method in Event.GetType().GetMethods()) {
				if(method.Name != "Execute") continue;

				canBeExecuted = true;

				if(method.GetParameters().Length == Entities.Length + 1) {
					object[] args = new object[Entities.Length + 1];
					args[0] = player;
					Array.Copy(Entities, 0, args, 1, Entities.Length);

					method.Invoke(Event, args);
					return;
				}
			}

			if(canBeExecuted) throw new MissingMethodException(Event.GetType().Name, $"Execute({Entities.Length})");
		}

		public override string ToString() =>
			$"SendEventCommand [Event: {Event}, Entities: {string.Join(", ", Entities.Select((entity) => entity.ToString()))}]";
	}
}
