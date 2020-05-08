using Blog.Domain.AuditableEntities;

using MediatR;

namespace Blog.Logic.UserAggregate.Querries.AuthenticateUser
{
	public class AuthenticateUserRequest : IRequest<User>
	{
		public string Email { get; set; }
		public string Password { get; set; }
	}
}