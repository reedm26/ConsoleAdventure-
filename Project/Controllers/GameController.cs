using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;
using ConsoleAdventure.Project.Services;

namespace ConsoleAdventure.Project.Controllers
{

  public class GameController : IGameController
  {
    private GameService _gameService = new GameService();
    private bool _running = true;
    //NOTE Makes sure everything is called to finish Setup and Starts the Game loop
    public void Run()
    {
      Console.WriteLine("Lets Start an adventure!");
      Console.WriteLine("What is your name?");
      string name = Console.ReadLine();
      Console.Clear();
      Console.WriteLine($"Lets start your adventure {name}");
      // _gameService.GetRoomDescription();

      while (_running)
      {
        GetUserInput();
        Print();
      }
      // Console.Clear();
    }


    //NOTE Gets the user input, calls the appropriate command, and passes on the option if needed.
    public void GetUserInput()
    {
      Console.WriteLine("");
      Console.WriteLine("--type help for options--");
      // Console.WriteLine("What would you like to do?");
      string input = Console.ReadLine().ToLower() + " ";
      string command = input.Substring(0, input.IndexOf(" "));
      string option = input.Substring(input.IndexOf(" ") + 1).Trim();
      //NOTE this will take the user input and parse it into a command and option.
      //IE: take silver key => command = "take" option = "silver key"
      switch (command)
      {
        case "go":
          _gameService.Go(option);
          break;
        case "look":
          _gameService.Look();
          break;
        case "help":
          _gameService.Help();
          break;
        case "inventory":
        case "i":
          _gameService.Inventory();
          break;
        case "quit":
        case "q":
        case "exit":
          _running = false;
          break;
        case "reset":
          _gameService.Reset();
          break;
        case "take":
          _gameService.TakeItem(option);
          break;
        case "use":
          _gameService.UseItem(option);
          break;
        default:
          System.Console.WriteLine("Invalid key");
          break;


      }


    }

    //NOTE this should print your messages for the game.
    private void Print()
    {
      Console.Clear();
      foreach (string message in _gameService.Messages)
      {
        Console.WriteLine(message);
      }
      _gameService.Messages.Clear();
    }

  }
}