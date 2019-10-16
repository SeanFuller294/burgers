using System.Collections.Generic;
using burgers.Interfaces;

namespace burgers.Models
{
  public class Burger : Iitem
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Id { get; set; }
  }
}