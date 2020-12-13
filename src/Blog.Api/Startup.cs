using System.Linq;
using System.Text;

using Blog.Api.Configuration;
using Blog.Api.Filters;
using Blog.Logic.CrossCuttingConcerns.Constants;
using Blog.Logic.CrossCuttingConcerns.Interfaces;
using Blog.Logic.CrossCuttingConcerns.Register;
using Blog.ORM.Context;
using Blog.ORM.Register;

using FluentValidation.AspNetCore;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

using NSwag;
using NSwag.Generation.Processors.Security;

using Serilog;
using Serilog.Events;

namespace Blog.Api
{
	public class Startup
	{
		private IServiceCollection _services;
		public IConfiguration Configuration { get; }
		public IWebHostEnvironment Environment { get; }



		public Startup(IConfiguration configuration, IWebHostEnvironment environment)
		{
			Configuration = configuration;
			Environment = environment;
		}



		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Log
			Log.Logger = new LoggerConfiguration()
			.MinimumLevel.Debug()
			.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
			.Enrich.FromLogContext()
			.WriteTo.Console()
			.WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
			.CreateLogger();

			// Validation
			services.AddControllers(options =>
				options.Filters.Add<ApiExceptionFilterAttribute>())
				.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<IDbContext>());

			// Register applications
			services.AddApplication();
			services.AddApi();
			services.AddPersistence(Configuration);

			// Health check
			services.AddHealthChecks().AddDbContextCheck<BlogContext>();

			// Register JWT Auth
			var key = Encoding.ASCII.GetBytes(ApplicationSettings.Secret);
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
				configure.AddSecurity("JWT",
					Enumerable.Empty<string>(),
					new OpenApiSecurityScheme
					{
						Type = OpenApiSecuritySchemeType.ApiKey,
						Name = "Authorization",
						In = OpenApiSecurityApiKeyLocation.Header,
						Description = "Type into the textbox: Bearer {your JWT token}."
					});

				configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
			});

			services.AddLogging();
			services.AddHttpContextAccessor();

			_services = services;
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
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHealthChecks("/health");
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseOpenApi(settings =>
			{
				settings.Path = "/api/{documentName}.json";
			});
			app.UseSwaggerUi3(settings =>
			{
				settings.Path = "/api";
				settings.DocumentPath = "/api/{documentName}.json";
			});

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
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
