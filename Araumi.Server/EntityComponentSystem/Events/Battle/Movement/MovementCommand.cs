using Araumi.Server.Protocol.Attributes;

namespace Araumi.Server.EntityComponentSystem.Events.Battle.Movement {
  public struct MoveCommand {
    [ProtocolOptional]
    public Components.Battle.Movement.Movement? Movement { get; set; }

    [ProtocolOptional] public float TankControlVertical { get; set; }
    [ProtocolOptional] public float TankControlHorizontal { get; set; }

    [ProtocolOptional] public float? WeaponRotation { get; set; }
    [ProtocolOptional] public float WeaponRotationControl { get; set; }

    public int ClientTime { get; set; }

    [ProtocolIgnore] public bool IsDiscrete => IsFloatDiscrete(TankControlVertical) &&
                                               IsFloatDiscrete(TankControlHorizontal) &&
                                               IsFloatDiscrete(WeaponRotationControl);

    private static bool IsFloatDiscrete(float value) => value is 0f or 1f or -1f;

    public override string ToString() => $"MoveCommand[Movement={Movement}, WeaponRotation={WeaponRotation}]";
  }
}
