using System;

using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Tank {
  [TypeUid(-2656312914607478436)]
  public class TankDeadStateComponent : Component {
    public DateTime EndTime { get; set; }

    public TankDeadStateComponent() {
      EndTime = DateTime.UtcNow.AddSeconds(3);
    }
  }
}
