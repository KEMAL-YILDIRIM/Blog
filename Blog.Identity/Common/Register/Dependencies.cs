using System.Collections.Generic;
using System.Security.Claims;

using Blog.Domain.CrossCuttingConcerns;
using Blog.Identity.Common.Services;
using Blog.Identity.Identity;
using Blog.Logic.Common.Constants;
using Blog.Logic.Common.Interfaces;

using IdentityModel;

using IdentityServer4.Models;
using IdentityServer4.Test;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Blog.Identity.Common.Register
{
	public static class Dependencies
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
		{
			services.AddScoped<IUserManager, UserManager>();
			services.AddTransient<INotificationService, NotificationService>();
			services.AddTransient<IDateTime, DateTimeService>();

			services.AddDbContext<IdentityDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString(BlogSettings.ConnectionStringName)));

			services.AddDefaultIdentity<ApplicationUser>()
				.AddEntityFrameworkStores<IdentityDbContext>();

			if (environment.IsEnvironment("Test"))
			{
				services.AddIdentityServer()
					.AddApiAuthorization<ApplicationUser, IdentityDbContext>(options =>
					{
						options.Clients.Add(new Client
						{
							ClientId = "Blog.IntegrationTests",
							AllowedGrantTypes = { GrantType.ResourceOwnerPassword },
							ClientSecrets = { new Secret("secret".Sha256()) },
							AllowedScopes = { "Blog.WebUIAPI", "openid", "profile" }
						});
					}).AddTestUsers(new List<TestUser>
					{
						new TestUser
						{
							SubjectId = "f26da293-02fb-4c90-be75-e4aa51e0bb17",
							Username = "kemal@blog",
							Password = "Blogtest1!",
							Claims = new List<Claim>
							{
								new Claim(JwtClaimTypes.Email, "kemal@blog")
							}
						}
					});
			}
			else
			{
				services.AddIdentityServer()
					.AddApiAuthorization<ApplicationUser, IdentityDbContext>();
			}

			services.AddAuthentication()
				.AddIdentityServerJwt();

			return services;
		}
	}
}
