using System.Threading.Tasks;

namespace Araumi.Server.Services.Servers.Game.Connection {
  public interface IPlayerConnection {
    public bool IsConnected { get; }

    public AsyncQueue<ICommand> CommandQueue { get; }

    public Task Init();
    public Task ReceivePackets();
    public Task SendPackets();

    public void QueueCommands(params ICommand[] commands);
    public Task SendCommands(params ICommand[] commands);
  }
}
