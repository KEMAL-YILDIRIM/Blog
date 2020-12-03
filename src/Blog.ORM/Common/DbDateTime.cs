using System;

using Blog.Logic.CrossCuttingConcerns.Interfaces;

namespace Blog.ORM.Common
{
	public class DbDateTime : IDateTime
	{
		public DateTime Now => DateTime.Now;
	}
}
