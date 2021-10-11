using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Player {
  /// <remarks>Original name: UserCountComponent</remarks>
  [TypeUid(1436520497855L)]
  public class BattlePlayerCountComponent : Component {
    [ProtocolName("UserCount")] public int PlayerCount { get; set; }

    public BattlePlayerCountComponent(int playerCount) {
      PlayerCount = playerCount;
    }
  }
}
