using System.Reflection;

using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;

namespace Araumi.Server {
  public class ServicesInstaller : IWindsorInstaller {
    public void Install(IWindsorContainer container, IConfigurationStore store) {
      container.Register(Classes.FromAssembly(Assembly.GetExecutingAssembly())
        .Where(Component.HasAttribute<ServiceAttribute>)
        .WithService.DefaultInterfaces()
        .LifestyleSingleton());
    }
  }
}
