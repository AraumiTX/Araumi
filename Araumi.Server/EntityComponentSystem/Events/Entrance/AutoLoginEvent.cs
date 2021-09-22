using Araumi.Server.EntityComponentSystem.Core;
using Araumi.Server.Protocol.Attributes;
using Araumi.Server.Services.Servers.Game;

namespace Araumi.Server.EntityComponentSystem.Events.Entrance {

  /// <remarks>Original name: AutoLoginUserEvent</remarks>
  [TypeUid(1438075609642)]
  public class AutoLoginEvent: IEvent {
    public string Uid { get; set; }
    public byte[] EncryptedToken { get; set; }
    public string HardwareFingerprint { get; set; }

    public void Execute(Player player, Entity entity) { }
  }
}
