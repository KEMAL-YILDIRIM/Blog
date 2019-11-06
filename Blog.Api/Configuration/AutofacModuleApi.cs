using Autofac;

using AutoMapper;

using Blog.Logic.Managers;

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
            builder.RegisterType<Mapper>().As<IMapper>().InstancePerLifetimeScope();
            builder.RegisterType<UserManager>().As<IUserManager>().InstancePerLifetimeScope();
        }
    }
}
