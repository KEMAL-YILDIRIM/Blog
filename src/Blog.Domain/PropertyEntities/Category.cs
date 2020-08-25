using Blog.Domain.CrossCuttingConcerns;
using Blog.Domain.LinkEntities;

using System.Collections.Generic;

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
