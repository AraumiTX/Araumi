using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Effect.EnergyInjection {
  [TypeUid(636367507221863506L)]
  public class EnergyInjectionModuleReloadEnergyComponent : Component {
    public float ReloadEnergyPercent { get; set; }

    public EnergyInjectionModuleReloadEnergyComponent(float reloadEnergyPercent) {
      ReloadEnergyPercent = reloadEnergyPercent;
    }
  }
}
