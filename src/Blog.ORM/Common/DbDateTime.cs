using Blog.Domain.CrossCuttingConcerns;

using System;

namespace Blog.ORM.Common
{
	public class DbDateTime : IDateTime
	{
		public DateTime Now => DateTime.Now;
	}
}
