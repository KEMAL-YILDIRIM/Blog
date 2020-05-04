using System;

using Blog.Domain.CrossCuttingConcerns;

namespace Blog.Identity.Common.Services
{
	public class DateTimeService : IDateTime
	{
		public DateTime Now => DateTime.Now;

		public int CurrentYear => DateTime.Now.Year;
	}
}
