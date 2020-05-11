using Autofac;
using Autofac.Extensions.DependencyInjection;

using Blog.Api.Common;
using Blog.Api.Configuration;
using Blog.Logic.CrossCuttingConcerns.Constants;
using Blog.Logic.CrossCuttingConcerns.Interfaces;
using Blog.Logic.CrossCuttingConcerns.Register;
using Blog.ORM.Context;

using FluentValidation.AspNetCore;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Text;

namespace Blog.Api
{
	public class Startup
	{
		private IServiceCollection _services;

		public Startup(IConfiguration configuration, IWebHostEnvironment environment)
		{
			Configuration = configuration;
			Environment = environment;
		}

		public IConfiguration Configuration { get; }
		public IWebHostEnvironment Environment { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			services.AddControllers()
				.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<IDbContext>());

			// Database
			services.AddHealthChecks().AddDbContextCheck<BlogContext>();
			services.AddDbContext<BlogContext>(options =>
			options.UseSqlServer("Server=Vault;Database=Blog;Trusted_Connection=True;MultipleActiveResultSets=true"));

			// Register applications
			services.AddApplication();

			// Register the Swagger
			services.AddSwaggerDocument(config =>
			{
				config.PostProcess = document =>
				{
					document.Info.Version = "v1";
					document.Info.Title = "Blog API";
					document.Info.Description = "Personal ASP.NET Core web API";
					document.Info.TermsOfService = "None";
					document.Info.Contact = new NSwag.OpenApiContact
					{
						Name = "Kemal YILDIRIM",
						Email = string.Empty,
						Url = "https://twitter.com/"
					};
					document.Info.License = new NSwag.OpenApiLicense
					{
						Name = "Use under MIT",
						Url = "/license"
					};
				};
			});

			// Register JWT Auth
			var key = Encoding.ASCII.GetBytes(BlogSettings.Secret);
			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(x =>
			{
				x.RequireHttpsMetadata = false;
				x.SaveToken = true;
				x.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false
				};
			});

			// Register Open API
			services.AddOpenApiDocument(configure =>
			{
				configure.Title = "Blog API";
			});

			_services = services;

			// Register autofac
			var containerBuilder = new ContainerBuilder();
			containerBuilder.RegisterModule<AutofacModuleApi>();
			containerBuilder.Populate(services);
			return new AutofacServiceProvider(containerBuilder.Build());
		}


		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app)
		{
			if (Environment.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				RegisteredServicesPage(app);
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseCustomExceptionHandler();
			app.UseHealthChecks("/health");
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseOpenApi();
			app.UseSwaggerUi3();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller}/{action=Index}/{id?}");
				endpoints.MapControllers();
			});
		}

		private void RegisteredServicesPage(IApplicationBuilder app)
		{
			app.Map("/services", builder => builder.Run(async context =>
			{
				var sb = new StringBuilder();
				sb.Append("<h1>Registered Services</h1>");
				sb.Append("<table><thead>");
				sb.Append("<tr><th>Type</th><th>Lifetime</th><th>Instance</th></tr>");
				sb.Append("</thead><tbody>");
				foreach (var svc in _services)
				{
					sb.Append("<tr>");
					sb.Append($"<td>{svc.ServiceType.FullName}</td>");
					sb.Append($"<td>{svc.Lifetime}</td>");
					sb.Append($"<td>{svc.ImplementationType?.FullName}</td>");
					sb.Append("</tr>");
				}
				sb.Append("</tbody></table>");
				await context.Response.WriteAsync(sb.ToString()).ConfigureAwait(false);
			}));
		}
	}
}
