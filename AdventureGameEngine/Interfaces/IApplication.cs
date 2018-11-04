using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureGameEngine.Interfaces
{
  public interface IApplication
  {
    Task Run(IList<ICommand> commands);
  }
}
