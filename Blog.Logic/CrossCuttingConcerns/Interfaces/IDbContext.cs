using Blog.Domain.AuditableEntities;
using Blog.Domain.ValueObjects;

using Microsoft.EntityFrameworkCore;

using System.Threading;
using System.Threading.Tasks;

namespace Blog.Logic.CrossCuttingConcerns.Interfaces
{
	public interface IDbContext
	{
		//Auditable Entities
		DbSet<Entry> Entries { get; set; }
		DbSet<User> Users { get; set; }


		//Property Entities

		//Value Types
		DbSet<RefreshToken> RefreshTokens { get; set; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}