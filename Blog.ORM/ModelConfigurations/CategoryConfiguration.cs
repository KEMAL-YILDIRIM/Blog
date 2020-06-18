using Blog.Domain.PropertyEntities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.ORM.ModelConfigurations
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasKey(e => e.Id);
		}
	}
}
