using System.Numerics;

using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Bonus {
  /// <remarks>Original name: RotationComponent</remarks>
  [TypeUid(-1853333282151870933)]
  public class BonusRotationComponent : Component {
    public Vector3 RotationEuler { get; set; }

    public BonusRotationComponent(Vector3 rotationEuler) {
      RotationEuler = rotationEuler;
    }
  }
}
