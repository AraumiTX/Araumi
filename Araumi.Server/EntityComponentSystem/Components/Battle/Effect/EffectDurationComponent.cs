using System;

using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Effect {
  /// <remarks>Original name: DurationComponent</remarks>
  [TypeUid(5192591761194414739L)]
  public class EffectDurationComponent : Component {
    public DateTime StartedTime { get; set; }

    public EffectDurationComponent(DateTime startedTime) {
      StartedTime = startedTime;
    }
  }
}
