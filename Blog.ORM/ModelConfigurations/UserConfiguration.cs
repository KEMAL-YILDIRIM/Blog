using Blog.Domain.AuditableEntities;
using Blog.Domain.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.ORM.ModelConfigurations
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(b => b.Id);
			builder.Property(b => b.Id).ValueGeneratedOnAdd();
			builder.HasMany<Entry>();
			builder.HasMany<Phone>();
		}
	}
}
