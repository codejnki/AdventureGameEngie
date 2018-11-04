using AdventureGameEngine.Interfaces;
using AdventureGameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameEngine.Commands
{
  public class HelpCommand : Command
  {
    public override string CommandName => "help";

    public override string HelpText => "The help command";

    public override Task Execute(IList<string> tokens, GameState gameState, IList<ICommand> commands)
    {
      if(tokens.Count == 1)
      {
        Console.WriteLine("Hello, I know the following commands.  Type help followed by a command name to learn more.");
        foreach(var c in commands.OrderBy(x => x.CommandName))
        {
          Console.WriteLine(c.CommandName);
        }

        return Task.FromResult(true);
      }

      var command = commands.Where(c => c.CommandName == tokens[1]).FirstOrDefault();

      if(command == null)
      {
        Console.WriteLine("I don't know that command.");
        return Task.FromResult(true);
      }

      Console.WriteLine($"The {command.CommandName} command");
      Console.WriteLine(command.HelpText);

      if (command.CommandNameAliases != null && command.CommandNameAliases.Any())
      {
        Console.WriteLine("Also known as:");
        foreach (var a in command.CommandNameAliases)
        {
          Console.WriteLine(a);
        }
      }

      return Task.FromResult(true);
    }
  }
}
