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
      if (_game.CurrentRoom.Exits.ContainsKey(direction) && !_game.CurrentRoom.useItem)
      {
        System.Console.Clear();
        _game.CurrentRoom = _game.CurrentRoom.Exits[direction];
        GetRoomDescription();
        Messages.Add("You could turn back now...");
        return;

      }
      else if (_game.CurrentRoom.useItem)
      {

      }
      Messages.Add("there is no exit here");
    }
    public void GetRoomDescription()
    {
      // System.Console.Clear();
      Messages.Add($"---- You are in: {_game.CurrentRoom.Name} ----");
      Messages.Add(_game.CurrentRoom.Description);
      Messages.Add("");
      Messages.Add("");
    }
    public void Help()
    {
      System.Console.Clear();

      Messages.Add("");
      Messages.Add("");
      Messages.Add("          --Help Guide--");
      Messages.Add("'go' then insert compass direction -");
      Messages.Add("'look' to see room description -");
      Messages.Add("'quit' to exit the game -");
      Messages.Add("'take' and item name, to grab item -");
      Messages.Add("");
      Messages.Add("");

    }

    public void Inventory()
    {
      if (_game.CurrentPlayer.Inventory.Count == 0)
      {
        Messages.Add("");
        Messages.Add("---You dont have any inventory!--- ");
      }
      foreach (var item in _game.CurrentPlayer.Inventory)
      {
        Messages.Add($"{item.Name}");
      }
    }

    public void Look()
    {
      GetRoomDescription();
      Messages.Add("----found items----");
      Messages.Add("");
      foreach (var item in _game.CurrentRoom.Items)
      {
        Messages.Add($"{item.Name}");
      }


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
      else if (_game.CurrentRoom.Items.Exists(i => i.Name.ToLower() == itemName))
      {

        var item = _game.CurrentRoom.Items.Find(i => i.Name.ToLower() == itemName);
        Messages.Add($"This {itemName} could help us out!");
        _game.CurrentPlayer.Inventory.Add(item);
        _game.CurrentRoom.Items.Remove(item);
      }
      else
      {
        Messages.Add("There is no such item");
      }
    }
    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public bool UseItem(string itemName)
    {
      if (_game.CurrentPlayer.Inventory.Exists(i => i.Name.ToLower() == itemName) && _game.CurrentRoom.useItem && itemName == _game.CurrentRoom.Locked.Name.ToLower())
      {

        _game.CurrentRoom.useItem = false;
        var doorKey = _game.CurrentPlayer.Inventory.Find(i => i.Name == itemName);
        _game.CurrentPlayer.Inventory.Remove(doorKey);
        Messages.Add("Come on threw to the other side!");
      }
      else if (_game.CurrentPlayer.Inventory.Exists(i => i.Name.ToLower() == itemName) && !_game.CurrentRoom.useItem)
      {
        Messages.Add("There might have been something you needed...");
        return true;
      }
      else
      {
        Messages.Add("You do not have an item like that.");
        return true;
      }

    }
  }
}