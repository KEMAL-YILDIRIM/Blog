
using Blog.Domain.CrossCuttingConcerns;
using Blog.Domain.Exceptions;
using Blog.Domain.PropertyEntities;

using System;

namespace Blog.Domain.AuditableEntities
{
	public class Entry : AuditableEntity, IEntity
	{
		#region Constructor

		public Entry()
		{
			Category = new Category();
			Content = new Content();
		}

		public Entry(
			string title,
			TimeSpan readingTime,

			Category category,
			Content content,

			string createdBy,
			string updatedBy,
			DateTime createdAt,
			DateTime? updatedAt)
			: base(createdBy, updatedBy, createdAt, updatedAt)
		{
			if (string.IsNullOrEmpty(title)) throw new PropertyNotFoundException("Entry -> Title");
			Title = title;
			ReadingTime = readingTime;

			Category = category;
			Content = content;
		}

		public Entry(
			string entryId,
			string title,
			TimeSpan readingTime,

			Category category,
			Content content,

			string createdBy,
			string updatedBy,
			DateTime createdAt,
			DateTime? updatedAt)
			: base(createdBy, updatedBy, createdAt, updatedAt)
		{
			if (string.IsNullOrEmpty(entryId)) throw new PropertyNotFoundException("Entry -> EntryId");
			EntryId = entryId;
			if (string.IsNullOrEmpty(title)) throw new PropertyNotFoundException("Entry -> Title");
			Title = title;
			ReadingTime = readingTime;

			Category = category;
			Content = content;
		}

		#endregion


		public string EntryId { get; private set; }
		public string Title { get; private set; }
		public TimeSpan ReadingTime { get; private set; }


		public Category Category { get; private set; }
		public Content Content { get; private set; }
	}
}
