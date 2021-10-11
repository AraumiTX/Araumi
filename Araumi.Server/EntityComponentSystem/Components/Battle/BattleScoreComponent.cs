using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle {
  [TypeUid(1436532217083L)]
  public class BattleScoreComponent : Component {
    public int Score { get; set; }

    public int ScoreRed { get; set; }
    public int ScoreBlue { get; set; }

    public BattleScoreComponent(int score, int scoreRed, int scoreBlue) {
      Score = score;

      ScoreRed = scoreRed;
      ScoreBlue = scoreBlue;
    }
  }
}
