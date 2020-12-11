using System;

using Blog.Logic.CrossCuttingConcerns.Interfaces;

namespace Blog.Logic.CrossCuttingConcerns.Exceptions
{
	public class DeleteFailureException : Exception, ILogicException
	{
		public DeleteFailureException(string name, object key, string message)
			: base($"Deletion of entity \"{name}\" ({key}) failed. {message}")
		{
		}
	}
}
