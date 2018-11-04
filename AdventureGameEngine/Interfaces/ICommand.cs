using AdventureGameEngine.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureGameEngine.Interfaces
{
  public interface ICommand
  {
    string CommandName { get; }

    IList<string> CommandNameAliases { get; }

    string HelpText { get; }

    Task<CommandResult> Execute(IList<string> tokens, GameState gameState, IList<ICommand> commands);
  }
}
