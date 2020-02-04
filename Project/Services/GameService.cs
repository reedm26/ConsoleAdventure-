using System.Collections.Generic;
using System;
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
        _game.CurrentRoom = _game.CurrentRoom.Exits[direction];
        GetRoomDescription();
        Look();
        return;
      }
      Messages.Add("there is no exit");
    }
    public void GetRoomDescription()
    {
      Messages.Add(_game.CurrentRoom.Description);

    }
    public void Help()
    {
      throw new System.NotImplementedException();
    }

    public void Inventory()
    {
      throw new System.NotImplementedException();
    }

    public void Look()
    {
      Messages.Add(_game.CurrentRoom.Description);
      return;
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

    }

    public void Setup(string playerName)
    {




    }
    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName)
    {
      throw new System.NotImplementedException();
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