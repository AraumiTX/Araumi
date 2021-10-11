using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Weapon.Shaft {
  [TypeUid(635950079224407790L)]
  public class ShaftStateConfigComponent : Component {
    public float WaitingToActivationTransitionTimeSec { get; set; }
    public float ActivationToWorkingTransitionTimeSec { get; set; }
    public float FinishToIdleTransitionTimeSec { get; set; }

    public ShaftStateConfigComponent(
      float waitingToActivationTransitionTimeSec,
      float activationToWorkingTransitionTimeSec,
      float finishToIdleTransitionTimeSec
    ) {
      WaitingToActivationTransitionTimeSec = waitingToActivationTransitionTimeSec;
      ActivationToWorkingTransitionTimeSec = activationToWorkingTransitionTimeSec;
      FinishToIdleTransitionTimeSec = finishToIdleTransitionTimeSec;
    }
  }
}
