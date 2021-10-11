using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Round {
  [TypeUid(6921761768819133913)]
  public class RoundUserStatisticsComponent : Component {
    public int Place { get; set; }

    public int ScoreWithoutBonuses { get; set; }

    public int Kills { get; set; }
    public int KillAssists { get; set; }

    public int Deaths { get; set; }

    public RoundUserStatisticsComponent(int place, int scoreWithoutBonuses, int kills, int killAssists, int deaths) {
      Place = place;
      ScoreWithoutBonuses = scoreWithoutBonuses;
      Kills = kills;
      KillAssists = killAssists;
      Deaths = deaths;
    }
  }
}
