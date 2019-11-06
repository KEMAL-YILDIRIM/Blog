using Autofac;

namespace Blog.Repositories.Configuration
{
    public class AutofacModuleRepositories : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<IUserManager>().As<UserManager>().InstancePerLifetimeScope();
        }
    }
}
