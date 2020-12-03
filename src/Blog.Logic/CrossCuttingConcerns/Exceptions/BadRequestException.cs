using Blog.Logic.CrossCuttingConcerns.Interfaces;

using System;

namespace Blog.Logic.CrossCuttingConcerns.Exceptions
{
	public class BadRequestException : Exception, ILogicException
	{
		public BadRequestException(string message)
			: base(message)
		{
		}
	}
}
