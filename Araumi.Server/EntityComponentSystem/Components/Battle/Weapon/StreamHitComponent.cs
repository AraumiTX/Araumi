using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;
using Araumi.Server.EntityComponentSystem.Types.Battle.Weapon;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Weapon {
  [TypeUid(-6274985110858845212L)]
  public class StreamHitComponent : Component {
    [ProtocolOptional] public HitTarget? TankHit { get; set; }
    [ProtocolOptional] public StaticHit? StaticHit { get; set; }
  }
}
