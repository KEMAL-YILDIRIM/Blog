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
			builder.HasKey(e => e.Id);

			builder.HasMany<Entry>();
			builder.HasMany<Phone>();

			builder.OwnsMany(p => p.RefreshTokens, oe =>
			{
				oe.HasKey(e => e.Token);
				oe.WithOwner()
				.HasForeignKey(e => e.OwnerId);
			});
		}
	}
}
