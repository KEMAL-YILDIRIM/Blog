using System.Threading.Tasks;

using Blog.Api.Services;
using Blog.Logic.UserAggregate.Commands.CreateUser;
using Blog.Logic.UserAggregate.Commands.GenerateRefreshToken;
using Blog.Logic.UserAggregate.Commands.UpdateRefreshToken;
using Blog.Logic.UserAggregate.Querries.AuthenticateUser;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
	[Authorize]
	public class UserController : BaseController
	{
		private readonly ITokenService _tokenService;

		public UserController(ITokenService tokenService)
		{
			_tokenService = tokenService;
		}

		/// <summary>
		/// Register a user.
		/// </summary>
		/// <remarks>
		/// Sample request:
		///
		///		POST /Register
		///		{
		///			"FirstName":"Aston",
		///			"LastName":"Martin",
		///			"Email":"para@mela.com",
		///			"Password":"123456"
		///		}
		///
		/// </remarks>
		/// <param name="registerModel"></param>
		/// <returns><see cref="OkResult"/></returns>
		/// <response code="200">Returns ok result</response>
		/// <response code="400">If the information is not valid</response>
		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Register([FromBody] CreateUserRequest registerModel)
		{
			// model validation
			if (!ModelState.IsValid)
				return ValidationProblem();

			// register
			await Mediator.Send(registerModel).ConfigureAwait(false);

			return Ok();
		}

		/// <summary>
		/// Update a user.
		/// </summary>
		/// <remarks>
		/// Sample request:
		///
		///		POST /Update
		///		{
		///			"UserId":"1f285bf8-3e78-47eb-8b39-e896d1a328cf",
		///			"FirstName":"Aston",
		///			"LastName":"Martin",
		///			"Email": aaaa@bbb.uuu,
		///			"Password": "123456"
		///		}
		///
		/// </remarks>
		/// <param name="updateModel"></param>
		/// <returns><see cref="OkResult"/></returns>
		/// <response code="200">Returns ok result</response>
		/// <response code="400">If the information is not valid</response>
		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Update([FromBody] UpdateUserRequest updateModel)
		{
			// model validation
			if (!ModelState.IsValid)
				return ValidationProblem();

			// update
			await Mediator.Send(updateModel).ConfigureAwait(false);

			return Ok();
		}

		/// <summary>
		/// Authenticates a user.
		/// </summary>
		/// <remarks>
		/// Sample request:
		///
		///		POST /Authenticate
		///		{
		///			"Email": aaaa@bbb.uuu,
		///			"Password": "123456"
		///		}
		///
		/// </remarks>
		/// <param name="authenticateModel"></param>
		/// <returns>An authenticated user along with a token <see cref="OkResult"/></returns>
		/// <response code="200">Returns the user with a newly created token</response>
		/// <response code="400">If the user does not exists</response>
		[AllowAnonymous]
		[HttpPost]
		[Route("/api/user/login")]
		[Route("/api/user/authenticate")]
		[Produces("application/json")]
		public async Task<IActionResult> Authenticate([FromBody] AuthenticateUserRequest authenticateModel)
		{
			if (!ModelState.IsValid)
				return ValidationProblem();

			var user = await Mediator.Send(authenticateModel)
				.ConfigureAwait(false);

			if (user == null)
				return Unauthorized(new { message = "Username or password is incorrect" });

			var jwtToken = _tokenService.GenerateJwtToken(user.UserId);

			var clientIp = _tokenService.GetClientIp(HttpContext);
			var refreshTokenRequest = new GenerateRefreshTokenRequest { UserId = user.UserId, ClientIp = clientIp };
			var refreshToken = await Mediator.Send(refreshTokenRequest)
				.ConfigureAwait(false);
			_tokenService.SetRefreshTokenCookie(refreshToken.Token, HttpContext);

			// return basic user info (without password) and token to store client side
			return Ok(new AuthenticatedUserModel
			{
				Id = user.UserId,
				Username = user.Username,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Token = jwtToken
			});
		}

		[AllowAnonymous]
		[HttpPost]
		[Produces("application/json")]
		public async Task<IActionResult> RefreshToken()
		{
			var currentRefreshToken = Request.Cookies["refreshToken"];
			if (currentRefreshToken is null)
				return Unauthorized(new { message = "Token not found" });

			var clientIp = _tokenService.GetClientIp(HttpContext);
			var refreshTokenRequest = new UpdateRefreshTokenRequest
			{
				ClientIp = clientIp,
				CurrentRefreshToken = currentRefreshToken
			};
			var response = await Mediator.Send(refreshTokenRequest)
				.ConfigureAwait(false);

			var jwt = _tokenService.GenerateJwtToken(response.UserId);

			_tokenService.SetRefreshTokenCookie(response.RefreshToken, HttpContext);

			return Ok(new
			{
				Token = jwt
			});
		}

		//[HttpPost]
		//public IActionResult RevokeToken([FromBody] RevokeTokenRequest model)
		//{
		//	// accept token from request body or cookie
		//	var token = model.Token ?? Request.Cookies["refreshToken"];

		//	if (string.IsNullOrEmpty(token))
		//		return BadRequest(new { message = "Token is required" });

		//	var response = _userService.RevokeToken(token, ipAddress());

		//	if (!response)
		//		return NotFound(new { message = "Token not found" });

		//	return Ok(new { message = "Token revoked" });
		//}
	}
}