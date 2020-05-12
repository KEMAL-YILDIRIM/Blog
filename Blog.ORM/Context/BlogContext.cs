using Blog.Domain.AuditableEntities;
using Blog.Domain.ValueObjects;
using Blog.Logic.CrossCuttingConcerns.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Blog.ORM.Context
{
	public partial class BlogContext : DbContext, IDbContext
	{
		public BlogContext()
		{

		}

		public BlogContext(DbContextOptions<BlogContext> options)
			: base(options)
		{

		}

		public DbSet<Entry> Entries { get; set; }
		public DbSet<Phone> Phones { get; set; }
		public DbSet<Content> Contents { get; set; }
		public DbSet<User> Users { get; set; }

	}
}
