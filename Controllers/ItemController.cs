using System.Collections.Generic;
using burgers.Models;
using burgers.Services;
using Microsoft.AspNetCore.Mvc;

namespace burgers.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ItemController : ControllerBase
  {
    private readonly ItemService _is;

    public ItemController(ItemService iserv)
    {
      _is = iserv;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ItemController>> Get()
    {
      try
      {
        return Ok(_is.Get());
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Item> Get(string id)
    {
      try
      {
        return Ok(_is.Get(id));
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Item> Post([FromBody] Item newItem)
    {
      try
      {
        return Ok(_is.Create(newItem));
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Item> Edit(string id, [FromBody] Item newItemData)
    {
      try
      {
        newItemData.Id = id;
        return Ok(_is.Edit(newItemData));
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(string id)
    {
      try
      {
        return Ok(_is.Delete(id));
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }
  }
}