using AdventureGameEngine.Interfaces;
using AdventureGameEngine.Models;
using System.Threading.Tasks;

namespace AdventureGameEngine.Factories
{
  internal class WorldFactory : IWorldFactory
  {
    public Task<World> Get()
    {
      var world = new World();

      var room1 = new Room
      {

        RoomName = "West Room",
        Description = "This is boring room.  There isn't very much exciting here."
      };

      var room2 = new Room
      {
        RoomName = "East Room",
        Description = "A more exciting room.  You are very glad you came here."
      };


      room1.Exits.Add(new Exit
      {
        Direction = Direction.East,
        Room = room2
      });

      room2.Exits.Add(new Exit
      {
        Direction = Direction.West,
        Room = room1
      });

      world.Rooms.Add(room1);
      world.Rooms.Add(room2);

      world.Player = new Player
      {
        CurrentLocation = room1
      };

      return Task.FromResult(world);
    }
  }
}
