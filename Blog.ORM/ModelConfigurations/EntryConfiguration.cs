using Blog.ORM.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.ORM.ModelConfigurations
{
	public class EntryConfiguration : IEntityTypeConfiguration<Entry>
	{
		public void Configure(EntityTypeBuilder<Entry> builder)
		{
			builder
				.HasOne<User>()
				.WithMany(u => u.Entries)
				.HasForeignKey(p => p.Author);
		}
	}
}
