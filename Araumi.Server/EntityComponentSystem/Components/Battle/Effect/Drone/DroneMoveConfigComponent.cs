using System.Numerics;

using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Effect.Drone {
  [TypeUid(3441234123559L)]
  public class DroneMoveConfigComponent : Component {
    public float Acceleration { get; set; } = 20;
    public Vector3 SpawnPosition { get; set; } = new Vector3(0, 4, 0);
    public Vector3 FlyPosition { get; set; } = new Vector3(0, 5, 0);
    public float RotationSpeed { get; set; } = 5;
    public float MoveSpeed { get; set; } = 100;
  }
}
