using System;
using System.Threading.Tasks;

using Serilog;

using Araumi.Server.Services;
using Araumi.Server.Services.Servers.Game;
using Araumi.Server.Services.Servers.Static;

namespace Araumi.Server.Cli {
  public static class Program {
    public static async Task Main(string[] args) {
      try {
        Log.Logger = new LoggerConfiguration()
          .WriteTo.Console()
          .CreateBootstrapLogger();

        ServiceManager.Instance.Init();
        ServiceManager.Instance.Container.Resolve<ILoggerService>().Init();
        await ServiceManager.Instance.Container.Resolve<IConfigService>().Init();
        await ServiceManager.Instance.Container.Resolve<IDatabaseService>().Init();
        await ServiceManager.Instance.Container.Resolve<IClientConfigService>().Init();
        await ServiceManager.Instance.Container.Resolve<IStaticServer>().Start();
        await ServiceManager.Instance.Container.Resolve<IGameServer>().Start();

        await ServiceManager.Instance.Container.Resolve<IExitWaitService>().WaitAsync();
        Log.Information("Stopping...");

        await ServiceManager.Instance.Container.Resolve<IDatabaseService>().DisposeAsync();

        ServiceManager.Instance.Dispose();
      } catch(Exception exception) {
        Log.Fatal(exception, "A fatal exception occurred");
      } finally {
        Log.Information("Server stopped, exiting...");
        Console.ReadLine();
      }
    }
  }
}
