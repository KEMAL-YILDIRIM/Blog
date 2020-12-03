using System;

namespace Blog.Logic.CrossCuttingConcerns.Interfaces
{
	public interface IDateTime
	{
		DateTime Now { get; }
	}
}
