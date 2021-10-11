using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Module {
  [TypeUid(1538548472363L)]
  public class JumpEffectConfigComponent : Component {
    public float ForceUpgradeMult { get; set; }

    public JumpEffectConfigComponent(float forceUpgradeMult) {
      ForceUpgradeMult = forceUpgradeMult;
    }
  }
}
