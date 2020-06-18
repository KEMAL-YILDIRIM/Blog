using Blog.Domain.AuditableEntities;
using Blog.Domain.PropertyEntities;
using Blog.Domain.ValueObjects;

using Microsoft.EntityFrameworkCore;

using System.Threading;
using System.Threading.Tasks;

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



		//Value Types
		DbSet<Phone> Phones { get; set; }
		DbSet<Address> Addresses { get; set; }
		DbSet<Status> Statuses { get; set; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}