using Blog.Logic.Common.Mappings;
using Blog.Logic.UserAggregate.Commands.CreateUser;

using System.ComponentModel.DataAnnotations;

namespace Blog.Api.Dtos
{
	public class RegisterDto : IMapTo<CreateUserRequest>
	{
		[Required]
		public string FullName { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
	}
}
