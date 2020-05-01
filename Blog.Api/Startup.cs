using System;

using Autofac;
using Autofac.Extensions.DependencyInjection;

using Blog.Api.Configuration;
using Blog.ORM.Context;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

			// Register applications


			// Register autofac
			var containerBuilder = new ContainerBuilder();
			containerBuilder.RegisterModule<AutofacModuleApi>();
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
