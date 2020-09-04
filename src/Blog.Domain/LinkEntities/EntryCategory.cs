using Blog.Domain.AuditableEntities;
using Blog.Domain.Common;
using Blog.Domain.PropertyEntities;

namespace Blog.Domain.LinkEntities
{
	public class EntryCategory : ILinkEntity
	{
		public string EntryId { get; set; }
		public int CategoryId { get; set; }

		public Entry Entry { get; set; }
		public Category Category { get; set; }
	}
}
