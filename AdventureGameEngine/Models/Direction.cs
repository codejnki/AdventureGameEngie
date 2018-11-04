namespace AdventureGameEngine.Models
{
  public class Direction
  {
    private Direction(string value) { Value = value;  }
    public string Value { get; set; }

    public static Direction North { get { return new Direction("North"); } }
    public static Direction NorthEast { get { return new Direction("North East"); } }
    public static Direction East { get { return new Direction("East"); } }
    public static Direction SouthEast { get { return new Direction("South East"); } }
    public static Direction South { get { return new Direction("South"); } }
    public static Direction SouthWest { get { return new Direction("South West"); } }
    public static Direction West { get { return new Direction("West"); } }
    public static Direction NorthWest { get { return new Direction("North West"); } }
    public static Direction Up { get { return new Direction("Up"); } }
    public static Direction Down { get { return new Direction("Down"); } }
  }
}
