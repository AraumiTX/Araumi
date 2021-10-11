using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Effect {
  /// <remarks>Original name: DurationConfigComponent</remarks>
  [TypeUid(482294559116673084L)]
  public class EffectDurationConfigComponent : Component {
    public long Duration { get; set; }

    public EffectDurationConfigComponent(long duration) {
      Duration = duration;
    }
  }
}
