
using Blog.Api.Services;
using Blog.Logic.CrossCuttingConcerns.Interfaces;

using Microsoft.Extensions.DependencyInjection;

namespace Blog.Api.Configuration
{
	/// <summary>
	/// Register instances
	/// </summary>
	public static class Dependencies
	{
		public static IServiceCollection AddApi(this IServiceCollection services)
		{
			services.AddTransient<ICurrentUserService, CurrentUserService>();

			return services;
		}
	}
}
