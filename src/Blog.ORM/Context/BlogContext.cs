using Blog.Domain.AuditableEntities;
using Blog.Domain.LinkEntities;
using Blog.Domain.PropertyEntities;
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

		//Auditable Entities
		public DbSet<User> Users { get; set; }
		public DbSet<Entry> Entries { get; set; }
		public DbSet<Content> Contents { get; set; }


		//Property Entities
		public DbSet<Type> Types { get; set; }
		public DbSet<Country> Countries { get; set; }
		public DbSet<City> Cities { get; set; }
		public DbSet<Category> Categories { get; set; }


		//Link Entities
		public DbSet<EntryCategory> EntryCategories { get; set; }


		//Value Objects
		public DbSet<Phone> Phones { get; set; }
		public DbSet<Address> Addresses { get; set; }
		public DbSet<Status> Statuses { get; set; }
		public DbSet<RefreshToken> RefreshTokens { get; set; }

	}
}
