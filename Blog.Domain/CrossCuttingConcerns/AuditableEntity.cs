using System;

namespace Blog.Domain.CrossCuttingConcerns
{
	public class AuditableEntity
	{
		public AuditableEntity()
		{

		}

		public AuditableEntity(string createdBy,
			string updatedBy,
			DateTime createdAt,
			DateTime? updatedAt)
		{
			CreatedBy = createdBy;
			UpdatedBy = updatedBy;
			CreatedAt = createdAt;
			UpdatedAt = updatedAt;
		}

		public string CreatedBy { get; private set; }
		public string UpdatedBy { get; private set; }
		public DateTime CreatedAt { get; private set; }
		public DateTime? UpdatedAt { get; private set; }
	}
}
