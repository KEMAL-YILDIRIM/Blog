using Blog.Domain.AuditableEntities;
using Blog.Domain.CrossCuttingConcerns;

using System.Collections.Generic;

namespace Blog.Domain.PropertyEntities
{
	public class Category : PropertyEntity
	{

		public Category(int id, string name) : base(id, name)
		{
			Entrys = new HashSet<Entry>();
		}

		public Category(string name) : base(name)
		{
			Entrys = new HashSet<Entry>();
		}

		public Category()
		{
			Entrys = new HashSet<Entry>();
		}

		public ICollection<Entry> Entrys { get; set; }
	}
}
