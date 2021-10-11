using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Effect.ExternalImpact {
  /// <remarks>Original name: SplashEffectComponent</remarks>
  [TypeUid(1542363613520L)]
  public class SplashEffectComponent : Component {
    public bool CanTargetTeammates { get; set; }

    public SplashEffectComponent(bool canTargetTeammates) {
      CanTargetTeammates = canTargetTeammates;
    }
  }
}
