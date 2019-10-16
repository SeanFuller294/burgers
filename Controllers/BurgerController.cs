using System;
using System.Collections.Generic;
using System.Linq;
using burgers.DB;
using burgers.Models;
using burgers.Services;
using Microsoft.AspNetCore.Mvc;

namespace burgers.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BurgersController : ControllerBase
  {
    private readonly BurgersService _bs;
    public BurgersController(BurgersService bs)
    {
      _bs = bs;
    }



    [HttpGet]
    public ActionResult<IEnumerable<Burger>> Get()
    {
      try
      {
        return Ok(_bs.Get());
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Burger> Get(string id)
    {
      try
      {

        return Ok(_bs.Get(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Burger> Post([FromBody] Burger NewBurger)
    {
      try
      {

        return Ok(_bs.Create(NewBurger));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPut("{id}")]
    public ActionResult<Burger> Edit(string id, [FromBody] Burger newBurgerData)
    {
      try
      {
        newBurgerData.Id = id;
        return Ok(_bs.Edit(newBurgerData));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(string id)
    {
      try
      {
        return Ok(_bs.Delete(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }


  }
}