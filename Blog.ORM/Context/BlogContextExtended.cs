using Blog.Domain.CrossCuttingConcerns;
using Blog.Logic.Common.Interfaces;

using Microsoft.EntityFrameworkCore;

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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogContext).Assembly);
		}
	}
}
