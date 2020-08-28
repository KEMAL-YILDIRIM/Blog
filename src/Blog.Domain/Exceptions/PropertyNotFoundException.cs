using System;

namespace Blog.Domain.Exceptions
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

		public PropertyNotFoundException(string entity, string property)
			: base($"\"{entity}\" -> ({property}) was not found.")
		{

		}
	}
}
