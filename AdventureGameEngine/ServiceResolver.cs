using Autofac;
using System.Reflection;

namespace AdventureGameEngine
{
  public class ServiceResolver
  {
    public IContainer Container { get; }

    public ServiceResolver()
    {
      var assembly = Assembly.GetEntryAssembly();
      var builder = new ContainerBuilder();
      builder.RegisterAssemblyTypes(assembly).As(t => t.GetInterfaces()).SingleInstance();
      this.Container = builder.Build();
    }
  }
}
