using System;

using Autofac;
using Autofac.Extensions.DependencyInjection;

using AutoMapper;

using Blog.Api.Configuration;
using Blog.Logic.Configuration;
using Blog.ORM.Context;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<BlogContext>(options =>
            options.UseSqlServer("Server=Vault;Database=Blog;Trusted_Connection=True;MultipleActiveResultSets=true"));

            // Register automapper
            services.AddAutoMapper(
                typeof(MapperProfileApi)
                , typeof(AutomapperProfileLogic));

            // Register autofac
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<AutofacModuleApi>();
            containerBuilder.RegisterModule<AutofacModuleLogic>();
            containerBuilder.Populate(services);
            return new AutofacServiceProvider(containerBuilder.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
