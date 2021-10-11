using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Battle {
  [TypeUid(6549840349742289518L)]
  public class BattleTankCollisionsComponent : Component {
    public long SemiActiveCollisionsPhase { get; set; }
  }
}
