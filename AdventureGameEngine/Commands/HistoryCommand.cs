using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureGameEngine.Interfaces;
using AdventureGameEngine.Models;

namespace AdventureGameEngine.Commands
{
  public class HistoryCommand : Command
  {
    public override string CommandName => "history";

    public override string HelpText => "Displays all the commands you've given so far.";

    public override Task<CommandResult> Execute(IList<string> tokens, GameState gameState, IList<ICommand> commands)
    {
      var sb = new List<string>();
      foreach(var c in gameState.World.Player.CommandHistory.OrderBy(x => x.Key))
      {
        sb.Add($"Turn {c.Key}: {c.Value}");
      }

      return Task.FromResult(new CommandResult(true, sb));
    }
  }
}
