using Blog.Logic.UserAggregate.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Logic.Tests.UserAggragate.Helpers
{
	public class PasswordHaherTests
	{
		public void Given_123456_Should_ReturnHashedPassword()
		{
			var hasher = new PasswordHasher();
		}
	}
}
