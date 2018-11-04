namespace AdventureGameEngine.Models
{
  public class GameState
  {
    public bool GameRunning { get; set; }

    public int TurnCounter { get; set; }

    public World World { get; set; }
  }
}
