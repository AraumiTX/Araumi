using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Weapon.Shaft {
  [TypeUid(-7212768015824297898L)]
  public class ShaftAimingSpeedComponent : Component {
    public float HorizontalAcceleration { get; set; }
    public float MaxHorizontalSpeed { get; set; }

    public float VerticalAcceleration { get; set; }
    public float MaxVerticalSpeed { get; set; }

    // TODO(Assasans): Check uses, changed parameter order (3 and 4)
    public ShaftAimingSpeedComponent(float horizontalAcceleration, float maxHorizontalSpeed, float verticalAcceleration, float maxVerticalSpeed) {
      HorizontalAcceleration = horizontalAcceleration;
      MaxHorizontalSpeed = maxHorizontalSpeed;

      VerticalAcceleration = verticalAcceleration;
      MaxVerticalSpeed = maxVerticalSpeed;
    }
  }
}
