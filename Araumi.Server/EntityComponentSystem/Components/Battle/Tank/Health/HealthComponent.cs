using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Tank.Health {
  /// <remarks>Original name: HealthComponent</remarks>
  [TypeUid(1949198098578360952)]
  public class TankHealthComponent : Component {
    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }

    public TankHealthComponent(float currentHealth, float maxHealth) {
      CurrentHealth = currentHealth;
      MaxHealth = maxHealth;
    }
  }
}
