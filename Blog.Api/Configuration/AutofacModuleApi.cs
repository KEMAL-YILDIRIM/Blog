using Autofac;

using AutoMapper;

using Blog.Api.Services;
using Blog.Logic.Common.Interfaces;

namespace Blog.Api.Configuration
{
	/// <summary>
	/// Autofac module to register instances
	/// </summary>
	public class AutofacModuleApi : Module
	{

		protected override void Load(ContainerBuilder builder)
		{
			// Register types
			builder.RegisterType<Mapper>().As<IMapper>()
				.SingleInstance()
				.AsSelf();

			builder.RegisterType<CurrentUserService>().As<ICurrentUserService>().InstancePerLifetimeScope();
		}
	}
}
