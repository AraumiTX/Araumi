using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

using System;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Module {
  [TypeUid(1486635434064L)]
  public class InventoryCooldownStateComponent : Component {
    public DateTime CooldownStartTime { get; set; }
    public int CooldownTime { get; set; }

    public InventoryCooldownStateComponent(DateTime cooldownStartTime, int cooldownTime) {
      CooldownStartTime = cooldownStartTime;
      CooldownTime = cooldownTime;
    }
  }
}
