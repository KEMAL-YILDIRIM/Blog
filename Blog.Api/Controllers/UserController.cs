
using Blog.Api.Dtos;
using Blog.Logic.CrossCuttingConcerns.Constants;
using Blog.Logic.UserAggregate.Commands.CreateUser;
using Blog.Logic.UserAggregate.Querries.AuthenticateUser;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Api.Controllers
{
	[Authorize]
	public class UserController : BaseController
	{
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
		{
			// model validation
			if (!ModelState.IsValid)
				return ValidationProblem();

			// register
			var model = Mapper.Map<RegisterDto, CreateUserRequest>(registerDto);
			var result = await Mediator.Send(model)
				.ConfigureAwait(false);

			return NoContent();
		}

		[AllowAnonymous]
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> Authenticate([FromBody]AuthenticateDto authenticateDto)
		{
			var model = Mapper.Map<AuthenticateDto, AuthenticateUserRequest>(authenticateDto);
			var user = await Mediator.Send(model).ConfigureAwait(false);

			if (user == null)
				return BadRequest(new { message = "Username or password is incorrect" });

			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(BlogSettings.Secret);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, user.Id.ToString())
				}),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			var tokenString = tokenHandler.WriteToken(token);

			// return basic user info (without password) and token to store client side
			return Ok(new
			{
				Id = user.Id,
				Username = user.Username,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Token = tokenString
			});
		}
	}
}