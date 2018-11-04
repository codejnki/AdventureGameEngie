using System.Collections.Generic;

namespace AdventureGameEngine.Models
{
  public class CommandResult
  {
    public bool CommandSuccessful { get; set; }

    public IList<string> CommandResultText { get; set; }

    public bool PlayerLocationChanged { get; set; }

    public CommandResult(bool commandSuccessful, IList<string> commandResultText, bool playerLocationChanged = false)
    {
      this.CommandResultText = commandResultText;
      this.CommandSuccessful = commandSuccessful;
      this.PlayerLocationChanged = playerLocationChanged;
    }

    public CommandResult(bool commandSuccessful, string commandResultText, bool playerLocationChanged = false)
    {
      this.CommandResultText = new List<string> { commandResultText };
      this.CommandSuccessful = commandSuccessful;
      this.PlayerLocationChanged = playerLocationChanged;
    }
  }
}
