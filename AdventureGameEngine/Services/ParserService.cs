using AdventureGameEngine.Interfaces;
using AdventureGameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureGameEngine.Services
{
  internal class ParserService : IParserService
  {
    public IList<ICommand> Commands { private get; set; }

    public async Task ParseInput(string input, GameState gameState)
    {
      gameState.World.Player.CommandHistory.Add(gameState.TurnCounter, input);
      var tokens = input.Split(null);

      var command = this.Commands
        .Where(c => c.CommandName == tokens.First().ToLowerInvariant() || c.CommandNameAliases.Any(x => x == tokens.First().ToLowerInvariant()))
        .FirstOrDefault();

      if(command == null)
      {
        Console.WriteLine("I don't understand what you wrote.");
      }
      else
      {
        await command.Execute(tokens, gameState, this.Commands);
      }
    }
  }
}
