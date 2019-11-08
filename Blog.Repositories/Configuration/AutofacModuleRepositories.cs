using Autofac;

using AutoMapper;

using Blog.Logic.Repositories;
using Blog.Repositories.Derived;

namespace Blog.Repositories.Configuration
{
    public class AutofacModuleRepositories : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>()
                .SingleInstance()
                .AsSelf();

            builder.RegisterType<Mapper>().As<IMapper>()
                .SingleInstance()
                .AsSelf();
        }
    }
}
