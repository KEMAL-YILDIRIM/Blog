using System;
using System.Collections.Generic;
using System.Linq;

using Blog.Logic.CrossCuttingConcerns.Interfaces;

using FluentValidation.Results;

namespace Blog.Logic.CrossCuttingConcerns.Exceptions
{
	public class ValidationException : Exception, ILogicException
	{
		public ValidationException()
			: base("One or more validation failures have occurred.")
		{
			Errors = new Dictionary<string, string[]>();
		}

		public ValidationException(IEnumerable<ValidationFailure> failures)
			: this()
		{
			Errors = failures
				.GroupBy(e => e.PropertyName, e => e.ErrorMessage)
				.ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
		}

		public IDictionary<string, string[]> Errors { get; }
	}
}
