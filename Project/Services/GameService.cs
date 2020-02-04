using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Services
{
  public class GameService : IGameService
  {
    private IGame _game { get; set; }

    public List<string> Messages { get; set; } = new List<string>();
    public GameService()
    {
      _game = new Game();
      Messages = new List<string>();
    }
    public void Go(string direction)
    {
      if (_game.CurrentRoom.Exits.ContainsKey(direction))
      {
        System.Console.Clear();
        _game.CurrentRoom = _game.CurrentRoom.Exits[direction];
        GetRoomDescription();
        System.Console.WriteLine("You could turn back now...");
        return;

      }
      Messages.Add("there is no exit here");
    }
    public void GetRoomDescription()
    {
      System.Console.Clear();
      Messages.Add($"---- You are in: {_game.CurrentRoom.Name} ----");
      Messages.Add(_game.CurrentRoom.Description);
    }
    public void Help()
    {
      GetRoomDescription();
    }

    public void Inventory()
    {
      throw new System.NotImplementedException();
    }

    public void Look()
    {

    }

    public void Quit()
    {
      throw new System.NotImplementedException();
    }
    ///<summary>
    ///Restarts the game 
    ///</summary>
    public void Reset()
    {
      _game.Setup();
    }

    public void Setup(string playerName)
    {
      throw new System.NotImplementedException();
    }
    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName)
    {
      if (_game.CurrentRoom.Items.Count == 0)
      {
        Messages.Add("There is nothing in here to take...");
      }
      Messages.Add($"This {itemName} could help us out!");
      _game.CurrentPlayer.Inventory.AddRange(_game.CurrentRoom.Items);
    }
    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      throw new System.NotImplementedException();
    }
  }
}