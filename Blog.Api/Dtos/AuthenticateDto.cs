using System.ComponentModel.DataAnnotations;

using Blog.Logic.CrossCuttingConcerns.Mappings;
using Blog.Logic.UserAggregate.Querries.AuthenticateUser;

namespace Blog.Api.Dtos
{
	public class AuthenticateDto : IMapTo<AuthenticateUserRequest>
	{
		[Required]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
	}
}
