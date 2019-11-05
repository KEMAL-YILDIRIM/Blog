using System;

using Autofac;
using Autofac.Extensions.DependencyInjection;

using Blog.ORM.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Api.Configuration
{
    /// <summary>
    /// Database autofac module
    /// </summary>
    public class DatabaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Most of the repository initialization strictly tied to this dependency
            builder.RegisterType<BlogContext>().InstancePerDependency();

            // Register SQL server connection
            var services = new ServiceCollection();

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<BlogContext>(options =>
                {
                    options.UseSqlServer("Server=Vault;Database=Blog;Trusted_Connection=True;MultipleActiveResultSets=true",
                        sqlServerOptionsAction: sqlOptions =>
                        {
                            sqlOptions.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                        })
                        .ConfigureWarnings((warningBuilder) => warningBuilder
                        .Throw(RelationalEventId.AmbientTransactionWarning))
                        .EnableSensitiveDataLogging(true);
                },
                ServiceLifetime.Scoped);

            builder.Populate(services);
        }
    }
}
