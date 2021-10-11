using Araumi.Server.Protocol;
using Araumi.Server.Protocol.Attributes;
using Araumi.Server.EntityComponentSystem.Core;

namespace Araumi.Server.EntityComponentSystem.Components.Groups {
  public abstract class GroupComponent : Component {
    [ProtocolIgnore] public long Key { get; set; }
    [ProtocolIgnore] public long TypeUid => TypeUidUtils.GetId(GetType());

    public GroupComponent(Entity entity) : this(entity.Id) { }

    public GroupComponent(long key) {
      Key = key;
    }
  }
}
