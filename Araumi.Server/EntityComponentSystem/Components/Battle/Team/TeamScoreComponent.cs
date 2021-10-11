using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Team {
  [TypeUid(-2440064891528955383)]
  public class TeamScoreComponent : Component {
    public int Score { get; set; }

    public TeamScoreComponent(int score) {
      Score = score;
    }
  }
}
