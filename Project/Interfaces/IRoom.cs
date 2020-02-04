using System.Collections.Generic;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Interfaces
{
  public interface IRoom
  {
    string Name { get; set; }
    string Description { get; set; }
    bool useItem { get; set; }
    List<Item> Items { get; set; }
    Item Light { get; set; }
    Item Locked { get; set; }
    Dictionary<string, IRoom> Exits { get; set; }
  }
}
