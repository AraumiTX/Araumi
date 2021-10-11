using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Effect.Mine {
  [TypeUid(636377093029435859L)]
  public class MineEffectTriggeringAreaComponent : Component {
    public float Radius { get; set; }

    public MineEffectTriggeringAreaComponent() {
      Radius = 2;
    }
  }
}
