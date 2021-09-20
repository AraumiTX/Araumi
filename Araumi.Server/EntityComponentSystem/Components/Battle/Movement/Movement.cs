using System.Numerics;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Movement {
  public struct Movement {
    public Vector3 Position { get; set; }
    public Vector3 Velocity { get; set; }
    public Vector3 AngularVelocity { get; set; }
    public Quaternion Orientation { get; set; }

    public Movement(Vector3 position, Vector3 velocity, Vector3 angularVelocity, Quaternion orientation) {
      Position = position;
      Velocity = velocity;
      AngularVelocity = angularVelocity;

      Orientation = orientation;
    }
  }
}
