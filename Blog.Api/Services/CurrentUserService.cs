using System;

using Microsoft.AspNetCore.Http;

namespace Blog.Api.Services
{
	public class CurrentUserService
	{
		public CurrentUserService(IHttpContextAccessor httpContextAccessor)
		{
			UserId = new Guid().ToString();
			IsAuthenticated = true;
		}

		public string UserId { get; }

		public bool IsAuthenticated { get; }
	}
}
