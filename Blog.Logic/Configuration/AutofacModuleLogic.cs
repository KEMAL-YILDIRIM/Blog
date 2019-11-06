using Autofac;

using Blog.Logic.Managers;
using Blog.Logic.Validators;

namespace Blog.Logic.Configuration
{
    public class AutofacModuleLogic : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserManager>().InstancePerLifetimeScope();
            builder.RegisterType<PasswordValidator>().As<IPasswordValidator>().InstancePerLifetimeScope();
            builder.RegisterType<EmailValidator>().As<IEmailValidator>().InstancePerLifetimeScope();
        }
    }
}
