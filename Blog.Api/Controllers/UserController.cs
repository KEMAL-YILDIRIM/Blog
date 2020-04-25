using AutoMapper;

using Blog.Api.Dtos;
using Blog.Domain.AuditableEntities;
using Blog.Logic.UserAggregate;
using Blog.Logic.Validators;

using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace Blog.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserManager _userManager;
		private readonly IPasswordValidator _passwordValidator;
		private readonly IMapper _mapper;

		public UserController(IUserManager userManager,
			IPasswordValidator passwordValidator,
			IMapper mapper)
		{
			_userManager = userManager;
			_passwordValidator = passwordValidator;
			_mapper = mapper;
		}

		[HttpPost("register")]
		public async Task<ActionResult> Register([FromBody] Register registerModel)
		{
			// set password rules
			_passwordValidator.RequiredLength = 6;
			_passwordValidator.RequireLowercase = true;


			// model validation
			if (!ModelState.IsValid)
				return ValidationProblem();

			// register
			var user = _mapper.Map<Register, User>(registerModel);
			var result = await _userManager.RegisterAsync(user).ConfigureAwait(true);

			if (!result.isValid)
				return BadRequest(result.error);

			return Ok();
		}
	}
}