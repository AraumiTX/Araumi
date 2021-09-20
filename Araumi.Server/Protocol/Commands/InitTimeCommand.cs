using System;
using System.Threading.Tasks;

using Araumi.Server.Protocol.Attributes;
using Araumi.Server.Services.Servers.Game;

namespace Araumi.Server.Protocol.Commands {
  [CommandCode(7)]
  public class InitTimeCommand : ICommand {
    public long ServerTime { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    public async Task OnReceive(Player player) {
      throw new NotSupportedException();
    }

    public override string ToString() => $"InitTimeCommand [ServerTime: {ServerTime}]";
  }
}
