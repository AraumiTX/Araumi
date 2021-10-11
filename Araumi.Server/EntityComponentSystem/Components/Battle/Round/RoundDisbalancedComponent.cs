using System;

using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;
using Araumi.Server.EntityComponentSystem.Types.Battle.Team;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Round {
  [TypeUid(3051892485776042754L)]
  public class RoundDisbalancedComponent : Component {
    public TeamColor Loser { get; set; }

    public int InitialDominationTimerSec { get; set; }
    public DateTime FinishTime { get; set; }

    public RoundDisbalancedComponent(TeamColor loser, int initialDominationTimerSec, DateTime finishTime) {
      Loser = loser;

      InitialDominationTimerSec = initialDominationTimerSec;
      FinishTime = finishTime;
    }
  }
}
