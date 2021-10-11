using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Time {
  [TypeUid(-3596341255560623830)]
  public class TimeLimitComponent : Component {
    public long TimeLimitSec { get; set; }
    public long WarmingUpTimeLimitSet { get; set; }

    public TimeLimitComponent(long timeLimitSec, long warmingUpTimeLimitSet) {
      TimeLimitSec = timeLimitSec;
      WarmingUpTimeLimitSet = warmingUpTimeLimitSet;
    }
  }
}
