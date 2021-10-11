using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Weapon {
  [TypeUid(2869455602943064305L)]
  // TODO(Assasans): Document fucking property names
  public class DamageWeakeningByDistanceComponent : Component {
    public float MinDamagePercent { get; set; }

    public float RadiusOfMaxDamage { get; set; }
    public float RadiusOfMinDamage { get; set; }

    public DamageWeakeningByDistanceComponent(float minDamagePercent, float radiusOfMaxDamage, float radiusOfMinDamage) {
      MinDamagePercent = minDamagePercent;
      RadiusOfMaxDamage = radiusOfMaxDamage;
      RadiusOfMinDamage = radiusOfMinDamage;
    }
  }
}
