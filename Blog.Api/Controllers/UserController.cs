using AutoMapper;

using Blog.Api.Dtos;
using Blog.Entities;
using Blog.Logic.Managers;

using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;

        public UserController(IUserManager userManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult Register([FromBody] Register registerModel)
        {
            if (!ModelState.IsValid)
                return ValidationProblem();

            var user = _mapper.Map<Register, User>(registerModel);
            var result = _userManager.Register(user);
            if (!result.isValid)
                return BadRequest(result.error);

            return Ok();
        }
    }
}