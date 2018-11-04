using AdventureGameEngine.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureGameEngine.Interfaces
{
  public interface IParserService
  {
    IList<ICommand> Commands { set; }

    Task ParseInput(string input, GameState gameState);
  }
}
