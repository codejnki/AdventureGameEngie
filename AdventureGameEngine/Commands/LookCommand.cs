using AdventureGameEngine.Interfaces;
using AdventureGameEngine.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureGameEngine.Commands
{
  public class LookCommand : Command
  {
    public override string CommandName => "look";

    public override string HelpText => "Gives a detailed view of where you are";

    public override Task<CommandResult> Execute(IList<string> tokens, GameState gameState, IList<ICommand> commands)
    {
      var sb = new List<string>();
      sb.Add(gameState.World.Player.CurrentLocation.Description);

      foreach(var e in gameState.World.Player.CurrentLocation.Exits)
      {
        sb.Add($"An exit {e.Direction.Value}");
      }

      return Task.FromResult(new CommandResult(true, sb));
    }
  }
}
