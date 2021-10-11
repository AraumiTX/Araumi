using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Effect.Mine {
  [TypeUid(1431927384785L)]
  public class MineConfigComponent : Component {
    public float DamageFrom { get; set; }
    public float DamageTo { get; set; }

    public long ActivationTime { get; set; }

    public float Impact { get; set; }

    public float BeginHideDistance { get; set; }
    public float HideRange { get; set; }

    public MineConfigComponent(long activationTime, float beginHideDistance, float hideRange, float impact) {
      DamageFrom = 400;
      DamageTo = 500;

      ActivationTime = activationTime;

      Impact = impact;

      BeginHideDistance = beginHideDistance;
      HideRange = hideRange;
    }
  }
}
