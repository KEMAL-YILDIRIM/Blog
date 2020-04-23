using Blog.Entities.Seed;

using System;

namespace Blog.Entities.AuditableEntities
{
	public class User : IEntity
	{
		public Guid UserId { get; set; }
		public string FullName { get; set; }
		public DateTime RegisteredAt { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Password { get; set; }
	}
}
