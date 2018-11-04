using AdventureGameEngine.Interfaces;
using AdventureGameEngine.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureGameEngine.Commands
{
  public class LookCommand : Command
  {
    public override string CommandName => "look";

    public override string HelpText => "Gives a detailed view of where you are";

    public override Task Execute(IList<string> tokens, GameState gameState, IList<ICommand> commands)
    {
      Console.WriteLine(gameState.World.Player.CurrentLocation.Description);

      foreach(var e in gameState.World.Player.CurrentLocation.Exits)
      {
        Console.WriteLine($"An exit {e.Direction.Value}");
      }

      return Task.FromResult(true);
    }
  }
}
