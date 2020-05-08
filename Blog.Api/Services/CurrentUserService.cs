
using Microsoft.AspNetCore.Http;

using System.Security.Claims;

namespace Blog.Api.Services
{
	public class CurrentUserService
	{
		public CurrentUserService(IHttpContextAccessor httpContextAccessor)
		{
			UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
			IsAuthenticated = UserId != null;
		}

		public string UserId { get; }

		public bool IsAuthenticated { get; }
	}
}
