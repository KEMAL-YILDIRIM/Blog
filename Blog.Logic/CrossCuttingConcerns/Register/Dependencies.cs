using System.Reflection;

using AutoMapper;

using Blog.Logic.CrossCuttingConcerns.Behaviours;
using Blog.Logic.UserAggregate.Helpers;
using Blog.Logic.Validators;

using MediatR;

using Microsoft.Extensions.DependencyInjection;


namespace Blog.Logic.CrossCuttingConcerns.Register
{
	public static class Dependencies
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddMediatR(Assembly.GetExecutingAssembly());
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
			services.AddTransient<IPasswordHasher, PasswordHasher>();
			services.AddTransient<IPasswordValidator, PasswordValidator>();

			return services;
		}
	}
}
