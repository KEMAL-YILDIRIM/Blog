using System;

namespace Blog.Logic.CrossCuttingConcerns.Exceptions
{
	public class BadRequestException : Exception
	{
		public BadRequestException(string message)
			: base(message)
		{
		}
	}
}
