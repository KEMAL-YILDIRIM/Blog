using System.Linq;

using Blog.Logic.Common.Models;

using Microsoft.AspNetCore.Identity;

namespace Blog.Identity.Identity
{
	public static class IdentityResultExtensions
	{
		public static Result ToApplicationResult(this IdentityResult result)
		{
			return result.Succeeded
				? Result.Success()
				: Result.Failure(result.Errors.Select(e => e.Description));
		}
	}
}
