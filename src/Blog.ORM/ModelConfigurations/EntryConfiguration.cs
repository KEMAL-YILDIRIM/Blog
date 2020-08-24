using Blog.Domain.AuditableEntities;
using Blog.Domain.PropertyEntities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.ORM.ModelConfigurations
{
	public class EntryConfiguration : IEntityTypeConfiguration<Entry>
	{
		public void Configure(EntityTypeBuilder<Entry> builder)
		{
			builder.HasKey(p => p.EntryId);

			builder.HasOne<Content>();
			builder.HasMany<Category>();

			builder
				.HasOne<User>()
				.WithMany(e => e.Entries)
				.HasForeignKey(e => e.CreatedBy);
		}
	}
}
