using Microsoft.AspNetCore.Http;

namespace Blog.Api.Services
{
	public interface ITokenService
	{
		string GenerateJwtToken(string userId);
		string GetClientIp(HttpContext httpContext);
		void SetRefreshTokenCookie(string token, HttpContext httpContext);
	}
}