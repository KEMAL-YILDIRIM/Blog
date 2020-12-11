using System;

namespace Blog.Logic.CrossCuttingConcerns.Exceptions
{
	public class ForbiddenAccessException : Exception
	{
		public ForbiddenAccessException() : base() { }
	}
}
