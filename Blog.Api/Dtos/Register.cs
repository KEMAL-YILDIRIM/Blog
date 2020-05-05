using System.ComponentModel.DataAnnotations;

using Blog.Logic.CrossCuttingConcerns.Mappings;
using Blog.Logic.UserAggregate.Commands.CreateUser;

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
