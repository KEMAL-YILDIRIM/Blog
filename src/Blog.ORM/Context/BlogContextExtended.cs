using Blog.Domain.CrossCuttingConcerns;
using Blog.Logic.CrossCuttingConcerns.Interfaces;

using Microsoft.EntityFrameworkCore;

using System.Threading;
using System.Threading.Tasks;

namespace Blog.ORM.Context
{
	public partial class BlogContext : DbContext
	{
		private readonly ICurrentUserService _currentUserService;
		private readonly IDateTime _dateTime;


		public BlogContext(
			DbContextOptions<BlogContext> options,
			ICurrentUserService currentUserService,
			IDateTime dateTime)
			: base(options)
		{
			_currentUserService = currentUserService;
			_dateTime = dateTime;
		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
			{
				switch (entry.State)
				{
					case EntityState.Added:
						entry.Entity.CreatedBy = _currentUserService.UserId;
						entry.Entity.CreatedAt = _dateTime.Now;
						break;
					case EntityState.Modified:
						entry.Entity.UpdatedBy = _currentUserService.UserId;
						entry.Entity.UpdatedAt = _dateTime.Now;
						break;
				}
			}

			return base.SaveChangesAsync(cancellationToken);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogContext).Assembly);
		}
	}
}
