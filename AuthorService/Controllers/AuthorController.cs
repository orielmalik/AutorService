using Authors.Api.Models;
using Utils;
using Microsoft.AspNetCore.Mvc;
namespace AuthorService.Controllers
{
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
        public IActionResult GetAuthors()
        {
             Author author=new Author(DateTime.Now,"gaya","avigdor","s@gmail.com");
            return Ok(author.Id);
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult CreateAuthor([FromBody]Author author)
        {
           
          Author boundary=_crudService.createAuthor(author);
          if(boundary.Id.StartsWith("ERR"))
          {
            return BadRequest(boundary.Id);
          }
            return Ok(boundary);
        }
    }
    } 
