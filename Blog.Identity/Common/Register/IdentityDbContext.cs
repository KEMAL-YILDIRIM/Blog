using Blog.Identity.Identity;

using IdentityServer4.EntityFramework.Options;

using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Blog.Identity.Common.Register
{
	public class IdentityDbContext : ApiAuthorizationDbContext<ApplicationUser>
	{
		public IdentityDbContext(
			DbContextOptions<IdentityDbContext> options,
			IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
		{
		}
	}
}
