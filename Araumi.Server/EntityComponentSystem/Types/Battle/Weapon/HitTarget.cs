using System.Numerics;

using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Types.Battle.Weapon {
  public class HitTarget {
    public Entity Entity { get; set; }
    public Entity IncarnationEntity { get; set; }

    public float HitDistance { get; set; }

    public Vector3 HitDirection { get; set; }
    public Vector3 LocalHitPoint { get; set; }
    public Vector3 TargetPosition { get; set; }
  }
}
