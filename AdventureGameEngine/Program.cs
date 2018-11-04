using AdventureGameEngine.Interfaces;
using Autofac;
using System.Collections.Generic;

namespace AdventureGameEngine
{
  class Program
  {
    static void Main(string[] args)
    {
      var serviceResolver = new ServiceResolver();
      var application = serviceResolver.Container.Resolve<IApplication>();
      var commands = serviceResolver.Container.Resolve<IList<ICommand>>();
      application.Run(commands).Wait();
    }
  }
}
