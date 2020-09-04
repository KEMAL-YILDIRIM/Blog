using System;

namespace Blog.Domain.Common
{
	//Set to public to allow to the properties to be changed in a central location
	public class AuditableEntity
	{
		public string CreatedBy { get; set; }
		public string UpdatedBy { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
	}
}
