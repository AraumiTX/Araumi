using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Tank.Incarnation {
  [TypeUid(1491549293967)]
  public class TankIncarnationKillStatisticsComponent : Component {
    public int Kills { get; set; }
  }
}
