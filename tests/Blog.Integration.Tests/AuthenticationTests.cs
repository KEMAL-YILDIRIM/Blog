using System.Threading.Tasks;

using Blog.Integration.Tests.Base;
using Blog.Logic.UserAggregate.Querries.AuthenticateUser;

using NUnit.Framework;

namespace Blog.Integration.Tests
{
	public class AuthenticationTests : TestBase
	{
		[TestCase("/api/user/login")]

		public async Task Given_CallToAuth_Should_ReturnSuccess(string url)
		{
			// Arrange
			var client = _factory.CreateClient();
			client.DefaultRequestHeaders.Add("X-Forwarded-For", "127.168.1.32");

			var content = new AuthenticateUserRequest
			{
				Email = "Jason.cogan@enn.www",
				Password = "123456"
			};

			// Act
			var response = await client.PostAsync(url, Utilities.GetRequestContent(content));

			// Assert
			response.EnsureSuccessStatusCode(); // Status Code 200-299
			var responseType = response.Content.Headers.ContentType.ToString();
			Assert.AreEqual("application/json; charset=utf-8", responseType);

		}
	}
}
