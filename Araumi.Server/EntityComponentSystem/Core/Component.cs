using System.Threading.Tasks;

using Araumi.Server.Protocol.Attributes;
using Araumi.Server.Services.Servers.Game;

namespace Araumi.Server.EntityComponentSystem.Core {
  public abstract class Component {
    [ProtocolIgnore] public Player? PlayerOnly { get; set; }

    public virtual async Task OnAttach(Player player, Entity entity) { }
    public virtual async Task OnChange(Player player, Entity entity) { }
    public virtual async Task OnRemove(Player player, Entity entity) { }
  }
}
