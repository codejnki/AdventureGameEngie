using System;
using System.Collections.Generic;

namespace AdventureGameEngine.Models
{
  public class Room
  {
    public Guid Id { get; }

    public string RoomName { get; set; }

    public string Description { get; set; }

    public IList<Exit> Exits { get; set; }

    public int TimesPlayerInRoom { get; set; }

    public Room()
    {
      this.Exits = new List<Exit>();
    }

    public Room(Guid id) : base()
    {
      this.Id = id;
      this.Exits = new List<Exit>();
    }
  }
}
