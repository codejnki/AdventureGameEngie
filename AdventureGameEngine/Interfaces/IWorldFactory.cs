using AdventureGameEngine.Models;
using System.Threading.Tasks;

namespace AdventureGameEngine.Interfaces
{
  interface IWorldFactory
  {
    Task<World> Get();
  }
}
