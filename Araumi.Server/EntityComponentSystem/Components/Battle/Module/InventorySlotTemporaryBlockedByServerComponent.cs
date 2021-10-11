using System;

using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;


namespace Araumi.Server.EntityComponentSystem.Components.Battle.Module {
  [TypeUid(636367520290400984L)]
  public class InventorySlotTemporaryBlockedByServerComponent : Component {
    public DateTime StartBlockTime { get; set; }
    [ProtocolName("BlockTimeMS")] public long BlockTime { get; set; }

    public InventorySlotTemporaryBlockedByServerComponent(DateTime startBlockTime, long blockTime) {
      StartBlockTime = startBlockTime;
      BlockTime = blockTime;
    }
  }
}
