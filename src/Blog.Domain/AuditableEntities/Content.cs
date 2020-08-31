using Blog.Domain.CrossCuttingConcerns;

namespace Blog.Domain.AuditableEntities
{
	public class Content : AuditableEntity, IEntity
	{
		public string ContentId { get; set; }
		public string Html { get; set; }
	}
}