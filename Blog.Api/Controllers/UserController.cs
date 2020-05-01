
using Blog.Api.Dtos;
using Blog.Logic.UserAggregate.Commands.CreateUser;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace Blog.Api.Controllers
{
	[Authorize]
	public class UserController : BaseController
	{
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult> Register([FromBody] RegisterDto registerModel)
		{
			// model validation
			if (!ModelState.IsValid)
				return ValidationProblem();

			// register
			var model = Mapper.Map<RegisterDto, CreateUserRequest>(registerModel);
			var result = await Mediator.Send(model)
				.ConfigureAwait(false);

			return NoContent();
		}
	}
}