using MediatR;

namespace Blog.Logic.UserAggregate.Commands.CreateUser
{
	public class UserCreated : INotification
	{
		public string UserId { get; set; }
	}
}
