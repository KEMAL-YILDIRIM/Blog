using Blog.Domain.ValueObjects;

using MediatR;

using System.Collections.Generic;

namespace Blog.Logic.UserAggregate.Commands.CreateUser
{
	public class CreateUserRequest : IRequest
	{
		public string Username { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public IEnumerable<Phone> Phones { get; set; }
	}
}
