using Blog.Logic.CrossCuttingConcerns.Interfaces;

using System;

namespace Blog.Logic.CrossCuttingConcerns.Exceptions
{
	public class DeleteFailureException : Exception, ILocigException
	{
		public DeleteFailureException(string name, object key, string message)
			: base($"Deletion of entity \"{name}\" ({key}) failed. {message}")
		{
		}
	}
}
