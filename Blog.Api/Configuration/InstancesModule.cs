using Autofac;

namespace Blog.Api.Configuration
{
    /// <summary>
    /// Autofac module to register instances
    /// </summary>
    public class InstancesModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            // Register types
            //builder.RegisterType<ServiceManager>().As<ServiceControl>().InstancePerLifetimeScope();

            //builder.RegisterType<OrganisationManager>()//Most important one for the CQRS
            //    .AsSelf()
            //    .As<IOrgProvider>()
            //    .As<IOrganisationManager>()
            //    .InstancePerLifetimeScope();
        }
    }
}
