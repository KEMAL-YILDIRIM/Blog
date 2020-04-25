using System;

using Autofac;
using Autofac.Extensions.DependencyInjection;

using AutoMapper;

using Blog.Api.Configuration;
using Blog.Logic.Configuration;
using Blog.ORM.Context;
using Blog.Repositories.Configuration;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public static IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<BlogContext>(options =>
            options.UseSqlServer("Server=Vault;Database=Blog;Trusted_Connection=True;MultipleActiveResultSets=true")); 

            // Register automapper
            services.AddAutoMapper(
                typeof(MapperProfileApi),
                typeof(AutomapperProfileLogic),
                typeof(AutomapperProfileRepositories)); 

            // Register autofac
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<AutofacModuleApi>();
            containerBuilder.RegisterModule<AutofacModuleLogic>();
            containerBuilder.RegisterModule<AutofacModuleRepositories>();
            containerBuilder.Populate(services);
            return new AutofacServiceProvider(containerBuilder.Build());
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
