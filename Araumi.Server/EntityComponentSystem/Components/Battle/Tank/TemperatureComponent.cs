using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Tank {
  [TypeUid(6673681254298647708L)]
  public class TemperatureComponent : Component {
    public float Temperature { get; set; }

    public TemperatureComponent(float temperature) {
      Temperature = temperature;
    }
  }
}
