using Blog.Entities.Seed;

using System;

namespace Blog.Entities.AuditableEntities
{
	public class Entry : AuditableEntity, IEntity
	{
		public Entry(
			string createdBy,
			string updatedBy,
			DateTime createdAt,
			DateTime? updatedAt)
			: base(createdBy, updatedBy, createdAt, updatedAt)
		{
		}

		public Guid EntryId { get; private set; }
		public TimeSpan ReadingTime { get; private set; }


		public string Title { get; private set; }
		public string Category { get; private set; }


		public Note Note { get; private set; }
	}
}
