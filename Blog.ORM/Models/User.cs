using Blog.Domain.ValueObjects;
using Blog.ORM.Context;

using System;
using System.Collections.Generic;

namespace Blog.ORM.Models
{
	public class User : IPersistance
	{
		public User()
		{

		}

		public Guid UserId { get; set; }
		public string FullName { get; set; }
		public string Email { get; set; }
		public Phone Phone { get; set; }
		public string Password { get; set; }

		public IEnumerable<Entry> Entries { get; set; }
	}
}
