using Blog.Domain.ValueObjects;

using MediatR;

using System.Collections.Generic;

namespace Blog.Logic.UserAggregate.Commands.CreateUser
{
	public class UpdateUserRequest : IRequest
	{
		public UpdateUserRequest()
		{
			Phones = new HashSet<Phone>();
		}

		public string UserName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public IEnumerable<Phone> Phones { get; set; }
	}
}
