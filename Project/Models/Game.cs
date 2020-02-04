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
      Player marcel = new Player("Marcel");

      //NOTE This is where i am adding items
      Item Candle = new Item("Candle", "This will make things easier to see.");
      Item Key = new Item("Key", "This might work for a door.");
      //NOTE This is where i assign each item to the right Room
      Room1.Items.Add(new Item(Key.Name, Key.Description));
      Room1.Items.Add(Candle);
      Room2.Items.Add(Key);
      Room2.Items.Add(Candle);
      //NOTE this is where i added all my exits to rooms
      Room1.Exits.Add("north", Room2);
      Room2.Exits.Add("north", Room3);
      Room2.Exits.Add("south", Room1);
      Room3.Exits.Add("north", Room4);
      Room3.Exits.Add("south", Room2);
      Room3.Exits.Add("east", SecretRoom);
      SecretRoom.Exits.Add("west", Room3);
      Room4.Exits.Add("south", Room3);

      CurrentPlayer = marcel;
      CurrentRoom = Room1;

    }
    public Game()
    {
      Setup();
    }

  }
}