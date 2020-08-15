using System;

namespace Blog.Domain.Exceptions
{
	public class ValueNotEqualException : Exception, IDomainException
	{
		public ValueNotEqualException(string message) : base(message)
		{
		}

		public ValueNotEqualException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public ValueNotEqualException()
		{
		}
	}
}
