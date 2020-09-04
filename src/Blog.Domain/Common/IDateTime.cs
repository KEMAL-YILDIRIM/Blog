using System;

namespace Blog.Domain.Common
{
	public interface IDateTime
	{
		DateTime Now { get; }
	}
}
