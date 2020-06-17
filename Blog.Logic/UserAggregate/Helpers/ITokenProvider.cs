using Blog.Domain.ValueObjects;

namespace Blog.Logic.UserAggregate.Helpers
{
	public interface ITokenProvider
	{
		RefreshToken GenerateToken(string userIp);
	}
}