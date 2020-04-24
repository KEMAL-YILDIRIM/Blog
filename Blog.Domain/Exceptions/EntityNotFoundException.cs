using System;

namespace Blog.Domain.Exceptions
{
	public class EntityNotFoundException : Exception, IDomainException
	{
		public EntityNotFoundException(string message) : base(message)
		{
		}

		public EntityNotFoundException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public EntityNotFoundException()
		{
		}
	}
}
