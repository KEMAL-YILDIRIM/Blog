
using System;
using System.Collections.Generic;
using System.Linq;

using Blog.Domain.CrossCuttingConcerns;
using Blog.Domain.Exceptions;
using Blog.Domain.PropertyEntities;

namespace Blog.Domain.AuditableEntities
{
	public class Entry : AuditableEntity, IEntity
	{
		#region Constructor

		public Entry()
		{
			Content = new Content();

			Categories = new HashSet<Category>();
		}

		public Entry(
			string title,
			TimeSpan readingTime,

			Content content,

			ICollection<Category> categories)
		{
			if (string.IsNullOrEmpty(title)) throw new PropertyNotFoundException("Entry -> Title");
			Title = title;
			ReadingTime = readingTime;

			Content = content;

			Categories = categories;
		}

		public Entry(
			string entryId,
			string title,
			TimeSpan readingTime,

			Content content,

			ICollection<Category> categories)
		{
			if (string.IsNullOrEmpty(entryId)) throw new PropertyNotFoundException("Entry -> EntryId");
			EntryId = entryId;
			if (string.IsNullOrEmpty(title)) throw new PropertyNotFoundException("Entry -> Title");
			Title = title;
			ReadingTime = readingTime;

			Content = content;

			Categories = categories;
		}

		#endregion


		public string EntryId { get; private set; }
		public string Title { get; private set; }
		public TimeSpan ReadingTime { get; private set; }


		public Content Content { get; private set; }


		public ICollection<Category> Categories { get; private set; }

		#region Behaviour
		public bool UpsertCategory(Category category)
		{
			if (category is null) throw new EntityNotFoundException("Entry -> Category");

			var current = Categories.FirstOrDefault(r => r.Id == category.Id);
			if (current != null)
				current = category;
			else
				Categories.Add(category);

			return true;
		}

		public bool RemoveCategory(Category category)
		{
			if (category is null) throw new EntityNotFoundException("Entry -> Category");

			if (!Categories.Contains(category)) return false;

			Categories.Remove(category);
			return true;
		}

		#endregion
	}
}
