using System;

using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Time {
  [TypeUid(1436521738148L)]
  public class BattleStartTimeComponent : Component {
    /// <remarks>ProtocolOptional is not used but set in the client</remarks>
    [ProtocolOptional] public long RoundStartTime { get; set; }

    public BattleStartTimeComponent(DateTimeOffset roundStartTime) {
      RoundStartTime = roundStartTime.ToUnixTimeMilliseconds();
    }
  }
}
