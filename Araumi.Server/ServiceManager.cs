using System;

using Serilog;

using Castle.Windsor;

using Araumi.Server.Extensions;

namespace Araumi.Server {
	public class ServiceManager : IDisposable {
		private static readonly ILogger Logger = Log.Logger.ForType<ServiceManager>();

		public static ServiceManager Instance { get; } = new ServiceManager();

		public WindsorContainer Container { get; }

		private ServiceManager() {
			Container = new WindsorContainer();
		}

		public void Init() {
			Container.Install(new ServicesInstaller());

			Logger.Information("Initialized");
		}

		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing) {
			Container.Dispose();
		}
	}
}
