using System.Collections.Generic;
using System.Data;
using burgers.Models;
using Dapper;

namespace burgers.Repositories
{
  public class ItemRepository
  {
    private readonly IDbConnection _db;


    public ItemRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Item> Get()
    {
      string sql = "SELECT * FROM items";
      return _db.Query<Item>(sql);
    }

    internal Item Get(string id)
    {
      string sql = "SELECT * FROM items WHERE id = @id";
      return _db.QueryFirstOrDefault<Item>(sql, new { id });
    }

    internal Item Exists(string property, string value)
    {
      string sql = "SELECT * FROM items WHERE @property = @value";
      return _db.QueryFirstOrDefault<Item>(sql, new { property, value });
    }

    internal void Create(Item newItem)
    {
      string sql = @"
        INSERT INTO items
        (id, name, description, price)
        VALUES
        (@Id, @Name, @Description, @Price)";
      _db.Execute(sql, newItem);
    }

    internal void Edit(Item editItemData)
    {
      string sql = "UPDATE items SET name = @Name, description = @Description, price = @Price WHERE id = @id";
      _db.Execute(sql, editItemData);
    }

    internal void Remove(string id)
    {
      string sql = "DELETE FROM items WHERE id = @id";
      _db.Execute(sql, new { id });
    }


  }
}