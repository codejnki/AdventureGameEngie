using System.Collections.Generic;

namespace AdventureGameEngine.Models
{
  public class Player
  {
    public Room CurrentLocation { get; set; }

    public Dictionary<int, string> CommandHistory { get; }

    public Player()
    {
      this.CommandHistory = new Dictionary<int, string>();
    }
  }
}
