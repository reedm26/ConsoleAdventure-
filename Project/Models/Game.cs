using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Game : IGame
  {

    public IRoom CurrentRoom { get; set; }
    public IPlayer CurrentPlayer { get; set; }

    //NOTE Make yo rooms here...
    public void Setup()
    {
      Room Room1 = new Room("Room 1", "This room is dark..");
      Room Room2 = new Room("Room 2", "This room is dark..");
      Room Room3 = new Room("Room 3", "This room is dark..");
      Room Room4 = new Room("Room 4", "This room is dark..");
      Room SecretRoom = new Room("Secret Room", "This room is dark..");
    }
    public Game(IRoom currentRoom, IPlayer currentPlayer)
    {
      this.CurrentRoom = currentRoom;
      this.CurrentPlayer = currentPlayer;

    }
  }
}