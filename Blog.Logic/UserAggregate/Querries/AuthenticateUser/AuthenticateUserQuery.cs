using Blog.Domain.AuditableEntities;
using Blog.Logic.CrossCuttingConcerns.Exceptions;
using Blog.Logic.CrossCuttingConcerns.Interfaces;
using Blog.Logic.UserAggregate.Helpers;

using MediatR;

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Logic.UserAggregate.Querries.AuthenticateUser
{
	public class AuthenticateUserQuery : IRequestHandler<AuthenticateUserRequest, User>
	{
		private readonly IDbContext _context;
		private readonly ICurrentUserService _userService;
		private readonly IMediator _mediator;
		private readonly IPasswordHasher _passwordHasher;

		public AuthenticateUserQuery(
			IDbContext context,
			ICurrentUserService userService,
			IMediator mediator,
			IPasswordHasher passwordHasher)
		{
			_context = context;
			_userService = userService;
			_mediator = mediator;
			_passwordHasher = passwordHasher;
		}

		public async Task<User> Handle(AuthenticateUserRequest request, CancellationToken cancellationToken)
		{
			var user = _context.Users
				.FirstOrDefault(u => u.Email.Equals(request.Email, StringComparison.InvariantCultureIgnoreCase));
			if (user is null)
				throw new NotFoundException("User", request.Email);

			if (!_passwordHasher.Verify(request.Password, user.Password))
				throw new NotFoundException("User", request.Email);

			await _mediator.Publish(new UserAuthenticated { UserId = user.Id }, cancellationToken).ConfigureAwait(false);

			return user;
		}
	}
}
