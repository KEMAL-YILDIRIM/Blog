using Blog.Integration.Tests.Common;

using NUnit.Framework;

namespace Blog.Integration.Tests
{
	public class TestBase
	{

		private protected IntegrationTestsWebApplicationFactory<Api.Startup> _factory;

		[SetUp]
		public void Setup()
		{

		}


		[OneTimeSetUp]
		public void Init()
		{
			_factory = new IntegrationTestsWebApplicationFactory<Api.Startup>();
		}
	}
}