using Araumi.Server.EntityComponentSystem.Core;
using Araumi.Server.Protocol.Attributes;

namespace Araumi.Server.EntityComponentSystem.Components.Entrance {
  [TypeUid(1453796862447)]
  public class ClientLocaleComponent : Component {
    public string LocaleCode { get; set; }

    public ClientLocaleComponent(string localeCode) {
      LocaleCode = localeCode;
    }
  }
}
