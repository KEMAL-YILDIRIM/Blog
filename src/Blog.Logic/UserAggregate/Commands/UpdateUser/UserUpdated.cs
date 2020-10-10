using MediatR;

namespace Blog.Logic.UserAggregate.Commands.CreateUser
{
	public class UserUpdated : INotification
	{
		public string UserId { get; set; }
	}
}
