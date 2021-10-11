using System.Collections.Generic;

using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Module {
  public abstract class ModuleEffectUpgradablePropertyComponent : Component {
    public List<float> UpgradeLevel2Values { get; set; }
    public bool LinearInterpolation { get; set; }

    public ModuleEffectUpgradablePropertyComponent() {
      UpgradeLevel2Values = new List<float>();
    }
  }
}
