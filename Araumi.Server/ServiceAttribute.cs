using System;

namespace Araumi.Server {
  [AttributeUsage(AttributeTargets.Class)]
  public sealed class ServiceAttribute : Attribute {
    public ServiceAttribute() { }
  }
}
