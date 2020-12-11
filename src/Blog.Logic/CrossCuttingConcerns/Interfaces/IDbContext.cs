using System.Threading;
using System.Threading.Tasks;

using Blog.Domain.AuditableEntities;
using Blog.Domain.LinkEntities;
using Blog.Domain.PropertyEntities;
using Blog.Domain.ValueObjects;

using Microsoft.EntityFrameworkCore;

namespace Blog.Logic.CrossCuttingConcerns.Interfaces
{
	public interface IDbContext
	{
		//Auditable Entities
		DbSet<User> Users { get; set; }
		DbSet<Entry> Entries { get; set; }
		DbSet<Content> Contents { get; set; }


		//Property Entities
		DbSet<Type> Types { get; set; }
		DbSet<Country> Countries { get; set; }
		DbSet<City> Cities { get; set; }
		DbSet<Category> Categories { get; set; }


		//Link Entities
		DbSet<EntryCategory> EntryCategories { get; set; }


		//Value Types
		DbSet<Phone> Phones { get; set; }
		DbSet<Address> Addresses { get; set; }
		DbSet<Status> Statuses { get; set; }
		DbSet<RefreshToken> RefreshTokens { get; set; }


		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}