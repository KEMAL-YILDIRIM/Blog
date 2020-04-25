using System;

namespace Blog.Logic.Common.Exceptions
{
	public class BadRequestException : Exception
	{
		public BadRequestException(string message)
			: base(message)
		{
		}
	}
}
