using System.Collections.Generic;

using Blog.Domain.Common;
using Blog.Domain.LinkEntities;

namespace Blog.Domain.PropertyEntities
{
	public class Category : PropertyEntity
	{

		public Category(int id, string name) : base(id, name)
		{
			EntryCategories = new HashSet<EntryCategory>();
		}

		public Category(string name) : base(name)
		{
			EntryCategories = new HashSet<EntryCategory>();
		}

		public Category()
		{
			EntryCategories = new HashSet<EntryCategory>();
		}

		public ICollection<EntryCategory> EntryCategories { get; set; }
	}
}
