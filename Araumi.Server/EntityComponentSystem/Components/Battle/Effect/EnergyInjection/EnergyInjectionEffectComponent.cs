using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Effect.EnergyInjection {
  [TypeUid(636367475685199712L)]
  public class EnergyInjectionEffectComponent : Component {
    public float ReloadEnergyPercent { get; set; }

    public EnergyInjectionEffectComponent(float reloadEnergyPercent) {
      ReloadEnergyPercent = reloadEnergyPercent;
    }
  }
}
