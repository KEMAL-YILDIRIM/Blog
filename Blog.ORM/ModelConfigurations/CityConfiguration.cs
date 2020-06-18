using Blog.Domain.PropertyEntities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.ORM.ModelConfigurations
{
	public class CityConfiguration : IEntityTypeConfiguration<City>
	{
		public void Configure(EntityTypeBuilder<City> builder)
		{
			builder.HasKey(e => e.Id);
		}
	}
}
