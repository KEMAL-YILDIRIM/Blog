using Blog.Domain.AuditableEntities;

using Microsoft.EntityFrameworkCore;

using System.Threading;
using System.Threading.Tasks;

namespace Blog.Logic.Common.Interfaces
{
	public interface IDbContext
	{
		//Auditable Entities
		DbSet<Entry> Entries { get; set; }
		DbSet<User> Users { get; set; }


		//Property Entities

		//Value Types


		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}