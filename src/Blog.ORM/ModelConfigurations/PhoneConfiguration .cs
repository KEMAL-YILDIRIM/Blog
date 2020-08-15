using Blog.Domain.AuditableEntities;
using Blog.Domain.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.ORM.ModelConfigurations
{
	public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
	{
		public void Configure(EntityTypeBuilder<Phone> builder)
		{
			builder.HasKey(e => e.Number);

			builder.HasOne<User>()
				.WithMany(e => e.Phones)
				.HasForeignKey(e => e.UserId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
