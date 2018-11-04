using AdventureGameEngine.Interfaces;
using AdventureGameEngine.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureGameEngine.Commands
{
  internal class ExitCommand : Command
  {
    public override string CommandName => "exit";

    public ExitCommand()
    {
      this.CommandNameAliases.Add("quit");
    }

    public override string HelpText => "Exits the game.";

    public override Task<CommandResult> Execute(IList<string> input, GameState gameState, IList<ICommand> commands)
    {
      gameState.GameRunning = false;

      var result = new CommandResult(true, "Good bye!");
      return Task.FromResult(result);
    }
  }
}
