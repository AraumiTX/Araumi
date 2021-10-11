using System;

using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Time {
  [TypeUid(92197374614905239)]
  public class RoundStopTimeComponent : Component {
    public long StopTime { get; set; }

    public RoundStopTimeComponent(DateTimeOffset stopTime) {
      StopTime = stopTime.ToUnixTimeMilliseconds();
    }
  }
}
