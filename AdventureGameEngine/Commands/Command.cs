using AdventureGameEngine.Interfaces;
using AdventureGameEngine.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureGameEngine.Commands
{
  public abstract class Command : ICommand
  {
    public abstract string CommandName { get; }
    public virtual IList<string> CommandNameAliases { get; }
    public abstract string HelpText { get; }

    public Command()
    {
      this.CommandNameAliases = new List<string>();
    }

    public abstract Task<CommandResult> Execute(IList<string> tokens, GameState gameState, IList<ICommand> commands);
  }
}
