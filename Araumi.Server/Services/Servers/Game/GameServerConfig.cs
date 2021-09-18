using System.Net;

namespace Araumi.Server.Services.Servers.Game {
  public class GameServerConfig {
    public IPAddress Address { get; set; } = null!;
    public IPAddress PublicAddress { get; set; } = null!;

    public int Port { get; set; }
  }
}
