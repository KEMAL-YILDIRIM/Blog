using System;

namespace Blog.Exceptions
{
	public class PropertyNotFoundException : Exception, IDomainException
	{
		public PropertyNotFoundException(string message) : base(message)
		{
		}

		public PropertyNotFoundException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public PropertyNotFoundException()
		{
		}
	}
}
