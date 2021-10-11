using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;
using Araumi.Server.EntityComponentSystem.Types.Battle.Bonus;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Bonus {
  [TypeUid(-3961778961585441606L)]
  public class BonusRegionComponent : Component {
    public BonusType Type { get; set; }

    public BonusRegionComponent(BonusType type) {
      Type = type;
    }
  }
}
