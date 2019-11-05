using Autofac;

using Blog.Logic.Managers;

namespace Blog.Logic.Configuration
{
    class AutofacModuleLogic : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IUserManager>().As<UserManager>().InstancePerLifetimeScope();
        }
    }
}
