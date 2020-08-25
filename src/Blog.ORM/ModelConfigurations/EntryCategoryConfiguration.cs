using Blog.Domain.AuditableEntities;
using Blog.Domain.LinkEntities;
using Blog.Domain.PropertyEntities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.ORM.ModelConfigurations
{
	public class EntryCategoryConfiguration : IEntityTypeConfiguration<EntryCategory>
	{
		public void Configure(EntityTypeBuilder<EntryCategory> builder)
		{
			builder.HasKey(e => new { e.EntryId, e.CategoryId });

			builder
				.HasOne<Entry>()
				.WithMany(e => e.EntryCategories)
				.HasForeignKey(e => e.EntryId);

			builder
				.HasOne<Category>()
				.WithMany(e => e.EntryCategories)
				.HasForeignKey(e => e.CategoryId);
		}
	}
}
