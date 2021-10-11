using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Weapon {
  [TypeUid(-5407563795844501148L)]
  public class StreamHitConfigComponent : Component {
    public float LocalCheckPeriod { get; set; }
    public float SendToServerPeriod { get; set; }

    public bool DetectStaticHit { get; set; }
  }
}
