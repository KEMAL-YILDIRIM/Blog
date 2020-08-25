
using Blog.Domain.CrossCuttingConcerns;
using Blog.Domain.Exceptions;
using Blog.Domain.LinkEntities;
using Blog.Domain.PropertyEntities;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Domain.AuditableEntities
{
	public class Entry : AuditableEntity, IEntity
	{
		#region Constructor

		public Entry()
		{
			Content = new Content();

			EntryCategories = new HashSet<EntryCategory>();
		}

		public Entry(
			string title,
			TimeSpan readingTime,

			Content content)
		{
			if (string.IsNullOrEmpty(title)) throw new PropertyNotFoundException("Entry -> Title");
			Title = title;
			ReadingTime = readingTime;

			Content = content;
		}

		public Entry(
			string entryId,
			string title,
			TimeSpan readingTime,

			Content content)
		{
			if (string.IsNullOrEmpty(entryId)) throw new PropertyNotFoundException("Entry -> EntryId");
			EntryId = entryId;
			if (string.IsNullOrEmpty(title)) throw new PropertyNotFoundException("Entry -> Title");
			Title = title;
			ReadingTime = readingTime;

			Content = content;
		}

		#endregion





		public string EntryId { get; private set; }
		public string Title { get; private set; }
		public TimeSpan ReadingTime { get; private set; }


		public Content Content { get; private set; }


		public ICollection<EntryCategory> EntryCategories { get; private set; }





		#region Behaviour
		public bool UpsertCategory(Category category)
		{
			if (category is null) throw new EntityNotFoundException("Entry -> Category");

			var current = EntryCategories.FirstOrDefault(r => r.CategoryId == category.Id);
			if (current is null)
				EntryCategories.Add(new EntryCategory
				{
					CategoryId = category.Id,
					EntryId = EntryId,
					Entry = this,
					Category = category
				});

			return true;
		}

		public bool RemoveCategory(Category category)
		{
			if (category is null) throw new EntityNotFoundException("Entry -> Category");

			var current = EntryCategories.FirstOrDefault(r => r.CategoryId == category.Id);
			if (current is null) return false;

			EntryCategories.Remove(current);
			return true;
		}

		#endregion
	}
}
