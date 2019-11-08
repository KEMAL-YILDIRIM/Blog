using Autofac;

using AutoMapper;

using Blog.Logic.Repositories;
using Blog.Repositories.Base;
using Blog.Repositories.Derived;

using DomainUser = Blog.Entities.User;
using PersistanceUser = Blog.ORM.Models.User;

namespace Blog.Repositories.Configuration
{
    public class AutofacModuleRepositories : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<Map<DomainUser, PersistanceUser>>().As<IMap<DomainUser, PersistanceUser>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<Mapper>().As<IMapper>()
                .SingleInstance()
                .AsSelf();
        }
    }
}
