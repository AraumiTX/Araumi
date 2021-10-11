using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Module {
  [TypeUid(636383014039871905L)]
  public class InventoryAmmunitionComponent : Component {
    public int CurrentCount { get; set; }
    public int MaxCount { get; set; }

    public InventoryAmmunitionComponent(int maxCount = 0) {
      CurrentCount = maxCount;
      MaxCount = maxCount;
    }
  }
}
