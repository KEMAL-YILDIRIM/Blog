using Autofac;

using AutoMapper;

using Blog.Logic.UserAggregate;

namespace Blog.Logic.Configuration
{
	public class AutofacModuleLogic : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			var assembly = typeof(UserManager).Assembly;

			builder.RegisterAssemblyTypes(assembly)
				   .Where(t => t.Name.EndsWith("Manager"))
				   .AsImplementedInterfaces()
				   .InstancePerLifetimeScope();

			builder.RegisterAssemblyTypes(assembly)
				   .Where(t => t.Name.EndsWith("Validator"))
				   .AsImplementedInterfaces()
				   .InstancePerLifetimeScope();

			builder.RegisterType<Mapper>().As<IMapper>()
				.SingleInstance()
				.AsSelf();
		}
	}
}
