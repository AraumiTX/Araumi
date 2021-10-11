using System.Numerics;

using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Tank {
  [TypeUid(1835748384321L)]
  public class TankJumpComponent : Component {
    public float StartTime { get; set; }
    public Vector3 Velocity { get; set; }
    public bool OnFly { get; set; }
    public bool Slowdown { get; set; }
    public float SlowdownStartTime { get; set; }
  }
}
