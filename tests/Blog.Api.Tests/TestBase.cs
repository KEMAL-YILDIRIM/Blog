using NUnit.Framework;

namespace Blog.Api.Tests
{
	public class TestBase
	{
		[SetUp]
		public void Setup()
		{
		}

		[TearDown]
		public void Clean()
		{

		}

		public TEntity GetInstance<TEntity>()
			where TEntity : class, new()
		{
			return new TEntity();
		}
	}
}