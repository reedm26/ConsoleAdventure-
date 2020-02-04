using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Room : IRoom
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public bool useItem { get; set; }
    public List<Item> Items { get; set; } = new List<Item>();
    public Item Light { get; set; }
    public Item Locked { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; } = new Dictionary<string, IRoom>();

    public Room(string name, string description)
    {
      Name = name;
      Description = description;
    }
  }
}