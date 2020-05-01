using System.Reflection;

using AutoMapper;

using Blog.Logic.Common.Behaviours;

using MediatR;

using Microsoft.Extensions.DependencyInjection;


namespace Blog.Logic.Common.Register
{
	public static class Dependencies
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddMediatR(Assembly.GetExecutingAssembly());
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

			return services;
		}
	}
}
