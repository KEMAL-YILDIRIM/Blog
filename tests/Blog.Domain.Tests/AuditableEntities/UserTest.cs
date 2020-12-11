using System.Linq;

using Blog.Domain.AuditableEntities;

using Moq;

using NUnit.Framework;

namespace Blog.Domain.Tests.AuditableEntities
{
	[TestFixture]
	public class UserTest : TestBase
	{
		[Test]
		public void Given_AddEntryToUser_Should_ReturnUserWithEntry()
		{
			var user = GetInstance<User>();
			var entry = Mock.Of<Entry>();

			user.UpsertEntry(entry);
			Assert.IsTrue(user.Entries.Any());
		}

		[Test]
		public void Given_AddSameEntryToUser_Should_ReturnUserWithOneEntry()
		{
			var user = GetInstance<User>();
			var entry = Mock.Of<Entry>();

			user.UpsertEntry(entry);
			user.UpsertEntry(entry);
			Assert.IsTrue(user.Entries.Count() == 1);
		}
	}
}
