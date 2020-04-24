using System;

namespace Blog.Domain.CrossCuttingConcerns
{
	public interface IDateTime
	{
		DateTime Now { get; }
	}
}
