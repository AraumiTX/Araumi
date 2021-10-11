using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle {
  /// <remarks>Original name: ScoreLimitComponent</remarks>
  [TypeUid(-3048295118496552479)]
  public class BattleScoreLimitComponent : Component {
    public int ScoreLimit { get; set; }

    public BattleScoreLimitComponent(int scoreLimit) {
      ScoreLimit = scoreLimit;
    }
  }
}
