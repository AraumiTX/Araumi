using Araumi.Server.EntityComponentSystem.Core;
using Araumi.Server.Extensions;
using Araumi.Server.Protocol.Attributes;
using Araumi.Server.Services.Servers.Game;

using Serilog;

namespace Araumi.Server.EntityComponentSystem.Events.Navigation {
  [TypeUid(1453867134827)]
  public class EnterScreenEvent : IEvent {
    private static readonly ILogger Logger = Log.Logger.ForType<EnterScreenEvent>();

    public const string EntranceScreen = "EntranceScreen";
    public const string RegistrationScreen = "RegistrationScreen";
    public const string MainScreen = "MainScreen";
    public const string PasswordResetEmailScreen = "EnterUserEmailScreenComponent";

    public string Screen { get; set; } = null!;

    public void Execute(Player player, Entity entity) {
      Logger.WithPlayer(player).Debug("Entered screen {Screen}", Screen);
    }
  }
}
