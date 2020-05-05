using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

namespace Blog.Logic.UserAggregate.Querries.AuthenticateUser
{
	public class AuthenticateUserQuery : IRequestHandler<AuthenticateUserRequest>
	{
		public Task<Unit> Handle(AuthenticateUserRequest request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
