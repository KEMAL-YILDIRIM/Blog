using Blog.Domain.PropertyEntities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Blog.ORM.ModelConfigurations
{
	public class TypeConfiguration : IEntityTypeConfiguration<Type>
	{
		public void Configure(EntityTypeBuilder<Domain.PropertyEntities.Type> builder)
		{
			builder.HasKey(e => e.Id);
		}
	}
}
