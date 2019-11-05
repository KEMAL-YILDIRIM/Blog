using Autofac;

namespace Blog.Api.Configuration
{
    public static class IoC
    {
        /// <summary>
        /// The configure IoC method.
        /// </summary>
        /// <returns>
        /// <see cref="ILifetimeScope"/>
        /// </returns>
        public static ILifetimeScope Container()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule<InstancesModule>();
            containerBuilder.RegisterModule<DatabaseModule>();

            return containerBuilder.Build();
        }
    }
}
