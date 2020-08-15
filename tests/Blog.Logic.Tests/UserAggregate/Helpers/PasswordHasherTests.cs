using Blog.Logic.UserAggregate.Helpers;

namespace Blog.Logic.Tests.UserAggregate.Helpers
{
	public class PasswordHasherTests
	{
		public void Given_123456_Should_ReturnHashedPassword()
		{
			var hasher = new PasswordHasher();
		}
	}
}
