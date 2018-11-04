using System.Collections.Generic;

namespace AdventureGameEngine.Models
{
  public class World
  {
    public IList<Room> Rooms { get; set; }

    public Player Player { get; set; }

    public World()
    {
      this.Rooms = new List<Room>();
    }
  }
}
