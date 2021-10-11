using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Effect.Rage {
  [TypeUid(636364996704090103L)]
  public class RageEffectComponent : Component {
    [ProtocolName("DecreaseCooldownPerKillMS")] public int DecreaseCooldownPerKillMillis { get; set; }

    public RageEffectComponent(int decreaseCooldownPerKillMillis) {
      DecreaseCooldownPerKillMillis = decreaseCooldownPerKillMillis;
    }
  }
}
