using System;

namespace Blog.Exceptions
{
	public class IdNotFoundException : Exception, IDomainException
	{
		public IdNotFoundException(string message) : base(message)
		{
		}

		public IdNotFoundException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public IdNotFoundException()
		{
		}
	}
}
