using Blog.Domain.CrossCuttingConcerns;
using Blog.Logic.CrossCuttingConcerns.Constants;

using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Blog.Api.Services
{
	public class TokenService : ITokenService
	{
		private IDateTime _dateTime;

		public TokenService(IDateTime dateTime)
		{
			_dateTime = dateTime;
		}


		public void SetRefreshTokenCookie(string token, HttpContext httpContext)
		{
			var cookieOptions = new CookieOptions
			{
				HttpOnly = true,
				Expires = _dateTime.Now.AddDays(7)
			};
			httpContext.Response.Cookies.Append("refreshToken", token, cookieOptions);
		}

		public string GetClientIp(HttpContext httpContext)
		{
			if (httpContext.Request.Headers.ContainsKey("X-Forwarded-For"))
				return httpContext.Request.Headers["X-Forwarded-For"];
			else
				return httpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
		}

		public string GenerateJwtToken(string userId)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(BlogSettings.Secret);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, userId)
				}),
				Expires = _dateTime.Now.AddMinutes(15),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}
