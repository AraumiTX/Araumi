using System.Threading.Tasks;

using Araumi.Server.Protocol.Attributes;
using Araumi.Server.Services.Servers.Game;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Events.Entrance {
  /// <remarks>Original name: AutoLoginUserEvent</remarks>
  [TypeUid(1438075609642)]
  public class UserAutoLoginEvent : IEvent {
    [ProtocolName("Uid")] public string Username { get; set; } = null!;
    public byte[] EncryptedToken { get; set; } = null!;
    public string HardwareFingerprint { get; set; } = null!;

    public async Task Execute(Player player, Entity clientSession) {
      // TODO(Assasans): Not Implemented
    }
  }
}
