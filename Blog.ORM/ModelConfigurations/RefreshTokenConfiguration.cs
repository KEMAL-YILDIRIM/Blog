using Blog.Domain.AuditableEntities;
using Blog.Domain.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.ORM.ModelConfigurations
{
	public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
	{
		public void Configure(EntityTypeBuilder<RefreshToken> builder)
		{
			builder.HasOne<User>()
				.WithMany(u => u.RefreshTokens)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasKey(r => r.Token);
		}
	}
}
