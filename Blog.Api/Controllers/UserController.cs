using Blog.Api.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public ActionResult Register([FromBody] Register registerModel)
        {
            if (!ModelState.IsValid)
                return ValidationProblem();

            return Ok();
        }
    }
}