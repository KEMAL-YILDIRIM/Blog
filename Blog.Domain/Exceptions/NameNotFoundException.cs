using System;

namespace Blog.Domain.Exceptions
{
	public class NameNotFoundException : Exception, IDomainException
	{
		public NameNotFoundException(string message) : base(message)
		{
		}

		public NameNotFoundException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public NameNotFoundException()
		{
		}
	}
}
