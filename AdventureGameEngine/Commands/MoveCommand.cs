using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureGameEngine.Interfaces;
using AdventureGameEngine.Models;

namespace AdventureGameEngine.Commands
{
  public class MoveCommand : Command
  {
    public override string CommandName => "move";

    public override string HelpText => "Move through an exit.  Example: Move east";

    public override Task Execute(IList<string> tokens, GameState gameState, IList<ICommand> commands)
    {
      var direction = this.GetDirection(tokens);

      if (direction == null)
      {
        Console.WriteLine("I have no idea what you are talking about.");
        return Task.FromResult(true);
      }

      var exit = gameState.World.Player.CurrentLocation.Exits.Where(e => e.Direction.Value == direction.Value).FirstOrDefault();

      if (exit == null)
      {
        Console.WriteLine("I don't see an exit in that direction.");
        return Task.FromResult(true);
      }

      gameState.World.Player.CurrentLocation = exit.Room;
      return Task.FromResult(true);
    }

    private Direction GetDirection(IList<string> tokens)
    {
      if (tokens.Count == 2)
      {
        switch (tokens[1].ToLowerInvariant())
        {
          case "north":
            return Direction.North;
          case "south":
            return Direction.South;
          case "east":
            return Direction.East;
          case "west":
            return Direction.West;
          case "up":
            return Direction.Up;
          case "down":
            return Direction.Down;
          default:
            return null;
        }
      }
      else if(tokens.Count == 3)
      {
        switch(tokens[1].ToLowerInvariant() + tokens[2].ToLowerInvariant())
        {
          case "northeast":
            return Direction.NorthEast;
          case "southeast":
            return Direction.SouthEast;
          case "southwest":
            return Direction.SouthWest;
          case "northwest":
            return Direction.NorthWest;
          default:
            return null;
        }
      }

      return null;
    }
  }
}
