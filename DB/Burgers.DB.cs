using System.Collections.Generic;
using burgers.Models;

namespace burgers.DB
{
  public class FakeDB
  {
    public List<Burger> Burgers { get; set; } = new List<Burger>();
  }
}