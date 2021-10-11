using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Effect.FireRing {
  [TypeUid(1542695311337L)]
  public class FireRingEffectComponent : Component {
    public long Duration { get; set; }

    public float TemperatureDelta { get; set; }
    public float TemperatureLimit { get; set; }

    public FireRingEffectComponent() {
      Duration = 4;

      TemperatureDelta = 150;
      TemperatureLimit = 60;
    }
  }
}
