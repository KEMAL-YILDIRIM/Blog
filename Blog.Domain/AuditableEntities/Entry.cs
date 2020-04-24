
using Blog.Domain.CrossCuttingConcerns;
using Blog.Domain.PropertyEntities;

using System;

namespace Blog.Domain.AuditableEntities
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


		public Category Category { get; private set; }


		public Content Content { get; private set; }
	}
}
