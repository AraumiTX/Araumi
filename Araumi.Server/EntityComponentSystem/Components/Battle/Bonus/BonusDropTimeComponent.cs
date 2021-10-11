using System;

using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle.Bonus {
  [TypeUid(-7944772313373733709)]
  public class BonusDropTimeComponent : Component {
    public DateTime DropTime { get; set; }

    public BonusDropTimeComponent(DateTime dropTime) {
      DropTime = dropTime;
    }
  }
}
