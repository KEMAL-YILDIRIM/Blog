using Blog.Domain.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.ORM.ModelConfigurations
{
	public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
	{
		public void Configure(EntityTypeBuilder<Phone> builder)
		{
			builder.HasKey(p => p.Number);
		}
	}
}
