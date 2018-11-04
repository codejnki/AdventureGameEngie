using AdventureGameEngine.Models;

namespace AdventureGameEngine.Interfaces
{
  interface IDisplayService
  {
    void UpdateDisplay(GameState gameState);

    void UpdateDisplay(GameState gameState, CommandResult commandResult);
  }
}
