using Blog.Logic.CrossCuttingConcerns.Interfaces;
using Blog.ORM.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.ORM.Register
{
	public static class Dependencies
	{
		public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<BlogContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("Blog")));

			services.AddScoped<IDbContext>(provider => provider.GetService<BlogContext>());

			return services;
		}
	}
}
