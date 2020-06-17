namespace Blog.Api.Services
{
	public interface ITokenService
	{
		string GenerateJwtToken(string userId);
		string GetClientIp();
		void SetRefreshTokenCookie(string token);
	}
}