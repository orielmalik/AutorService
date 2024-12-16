using Authors.Api.Models;
using Utils;
using System;
using Microsoft.AspNetCore.Mvc;
namespace AuthorService.Controllers
{

  /*
  [FromBody]-->Request Body
  [FromQuery]-->Request Param
  [FromUri]-->Path Variable

  */

  [ApiController]
  [Route("[controller]")]
  public class AuthorController : ControllerBase
  {
    private readonly AuthorCrud _crudService;

    public AuthorController(AuthorCrud crudService)
    {
      _crudService = crudService;
    }

    [HttpGet]
    [Produces("text/event-stream")]
    public IActionResult GetAuthors([FromQuery] string type, [FromQuery] string value)
    {
      /*
       "Searching for lenient conditions, meaning if the user made a mistake in the input format, an empty list would be returned, and naturally, the server wouldn't waste resources
      */

      if (string.IsNullOrEmpty(type) && !string.IsNullOrEmpty(value))
      {
        return BadRequest("Bad Request");
      }
      try
      {
        return Ok(_crudService.getAuthors(type, value));

      }
      catch (FormatException f)
      {
        return BadRequest(f.Message.ToString());
      }
    }

    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]
    public IActionResult CreateAuthor([FromBody] AuthorBoundary author)
    {
      if(string.IsNullOrEmpty(author.Id))
      {
        author.Id=Guid.NewGuid().ToString();
      }
      Author entity;
      try{ 
        entity= _crudService.createAuthor(author.ToAuthor());

      }catch(Exception e)
      {
        return BadRequest(e.Message);
      }
      
      if (string.IsNullOrEmpty(author.Id))
      {
        return BadRequest("bad");
      }
     
      return Ok(new AuthorBoundary(entity));
    }


    [HttpDelete]
    public IActionResult deleteAll()
  {
    try{
    _crudService.deleteAuthors();

    }catch(Exception e)
    {
      return NotFound(e.Message);
    }
    return Ok("DeleteAll");

  }
  }
  
}
