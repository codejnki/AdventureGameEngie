using AdventureGameEngine.Interfaces;
using AdventureGameEngine.Models;
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

    public override Task<CommandResult> Execute(IList<string> tokens, GameState gameState, IList<ICommand> commands)
    {
      if(tokens.Count == 1)
      {
        var simpleHelp = new List<string>();
        simpleHelp.Add("Hello, I know the following commands.  Type help followed by a command name to learn more.");
        foreach(var c in commands.OrderBy(x => x.CommandName))
        {
          simpleHelp.Add(c.CommandName);
        }

        return Task.FromResult(new CommandResult(true, simpleHelp));
      }

      var command = commands.Where(c => c.CommandName == tokens[1]).FirstOrDefault();

      if(command == null)
      {
        return Task.FromResult(new CommandResult(false, "I don't know that command."));
      }

      var responses = new List<string>();
      responses.Add($"The {command.CommandName} command");
      responses.Add(command.HelpText);

      if (command.CommandNameAliases != null && command.CommandNameAliases.Any())
      {
        responses.Add("Also known as:");
        foreach (var a in command.CommandNameAliases)
        {
          responses.Add(a);
        }
      }

      return Task.FromResult(new CommandResult(true, responses));
    }
  }
}
