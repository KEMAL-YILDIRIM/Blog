using Blog.Domain.AuditableEntities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.ORM.ModelConfigurations
{
	public class ContentConfiguration : IEntityTypeConfiguration<Content>
	{
		public void Configure(EntityTypeBuilder<Content> builder)
		{
			builder.HasKey(p => p.ContentId);

			builder.HasOne<Entry>();
		}
	}
}
