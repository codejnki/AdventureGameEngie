using System;
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

    public override Task Execute(IList<string> tokens, GameState gameState, IList<ICommand> commands)
    {
      foreach(var c in gameState.World.Player.CommandHistory.OrderBy(x => x.Key))
      {
        Console.WriteLine($"Turn {c.Key}: {c.Value}");
      }

      return Task.FromResult(true);
    }
  }
}
