using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Tank.Health {
  /// <remarks>Original name: HealthConfigComponent</remarks>
  [TypeUid(8420700272384380156)]
  public class TankHealthConfigComponent : Component {
    public float BaseHealth { get; set; }

    public TankHealthConfigComponent(float baseHealth) {
      BaseHealth = baseHealth;
    }
  }
}
