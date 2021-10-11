using System.Numerics;

using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Weapon.Shaft {
  [TypeUid(8445798616771064825L)]
  public class ShaftAimingTargetPointComponent : Component {
    public bool IsInsideTankPart { get; set; }

    [ProtocolOptional] public Vector3? Point { get; set; }
  }
}
