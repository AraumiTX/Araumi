using System;

using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.User {
  /// <remarks>Original name: IdleCounterComponent</remarks>
  [TypeUid(2930474294118078222)]
  public class BattleUserIdleCounterComponent : Component {
    [ProtocolOptional] public DateTime? SkipBeginDate { get; set; }
    public long SkippedMillis { get; set; }

    public BattleUserIdleCounterComponent(long skippedMillis, DateTime? skipBeginDate = null) {
      SkipBeginDate = skipBeginDate;
      SkippedMillis = skippedMillis;
    }
  }
}
