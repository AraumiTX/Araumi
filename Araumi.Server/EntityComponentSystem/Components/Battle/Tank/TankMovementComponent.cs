using Araumi.Server.EntityComponentSystem.Components.Battle.Movement;
using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Tank {
  [TypeUid(-615965945505672897)]
  public class TankMovementComponent : Component {
    public Movement.Movement Movement { get; set; }
    public MoveControl MoveControl { get; set; }

    public float WeaponRotation { get; set; }
    public float WeaponControl { get; set; }

    public TankMovementComponent(Movement.Movement movement, MoveControl moveControl, float weaponRotation, float weaponControl) {
      Movement = movement;
      MoveControl = moveControl;

      WeaponRotation = weaponRotation;
      WeaponControl = weaponControl;
    }
  }
}
