using MediatR;

namespace Blog.Logic.UserAggregate.Querries.AuthenticateUser
{
	public class UserAuthenticated : INotification
	{
		public string UserId { get; set; }
	}
}
