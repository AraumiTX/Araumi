using Araumi.Server.EntityComponentSystem.Core;
using Araumi.Server.Protocol.Attributes;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Weapon.Hammer {
  [TypeUid(1464955716416L)]
  public class HammerPelletConeComponent : Component {
    public float HorizontalConeHalfAngle { get; set; }
    public float VerticalConeHalfAngle { get; set; }

    public int PelletCount { get; set; }

    public HammerPelletConeComponent(float horizontalConeHalfAngle, float verticalConeHalfAngle, int pelletCount) {
      HorizontalConeHalfAngle = horizontalConeHalfAngle;
      VerticalConeHalfAngle = verticalConeHalfAngle;
      PelletCount = pelletCount;
    }
  }
}
