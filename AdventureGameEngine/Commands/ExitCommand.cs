using AdventureGameEngine.Interfaces;
using AdventureGameEngine.Models;
using System;
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

    public override Task Execute(IList<string> input, GameState gameState, IList<ICommand> commands)
    {
      gameState.GameRunning = false;
      Console.WriteLine("Good bye!");
      return Task.FromResult(true);
    }
  }
}
