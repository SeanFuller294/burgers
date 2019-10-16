using System;
using System.Collections.Generic;
using System.Data;
using burgers.Models;
using Dapper;

namespace burgers.Repositories
{
  public class BurgerRepository
  {
    private readonly IDbConnection _db;

    public BurgerRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Burger> Get()
    {
      string sql = "SELECT * FROM burgers";
      //Dapper will call to the database and all objects return will be cast to <Burger>
      return _db.Query<Burger>(sql);
    }

    internal Burger Get(string id)
    {
      string sql = "SELECT * FROM burgers WHERE id = @id";
      //Dapper requires a second object that it can pull the properties off of
      return _db.QueryFirstOrDefault<Burger>(sql, new { id });
    }

    internal Burger Exists(string property, string value)
    {
      string sql = "SELECT * FROM burgers WHERE @property = @value";
      return _db.QueryFirstOrDefault<Burger>(sql, new { property, value });
    }

    internal void Create(Burger newBurger)
    {
      string sql = @"
      INSERT INTO burgers
      (id, name, description, price)
      VALUES
      (@Id, @Name, @Description, @Price)
      ";

      _db.Execute(sql, newBurger);
    }

    internal void Edit(Burger editBurgerData)
    {
      string sql = @"
      UPDATE burgers SET name = @Name, description = @Description, price = @Price WHERE id = @id";
      _db.Execute(sql, editBurgerData);
    }
    internal void Remove(string id)
    {
      string sql = "DELETE FROM burgers WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}