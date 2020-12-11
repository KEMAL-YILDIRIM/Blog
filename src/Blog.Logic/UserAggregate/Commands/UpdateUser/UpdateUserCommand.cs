using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Blog.Domain.Exceptions;
using Blog.Domain.ValueObjects;
using Blog.Logic.CrossCuttingConcerns.Interfaces;
using Blog.Logic.UserAggregate.Helpers;

using MediatR;

namespace Blog.Logic.UserAggregate.Commands.CreateUser
{
	public class UpdateUserCommand : IRequestHandler<UpdateUserRequest>
	{
		private readonly IDbContext _context;
		private readonly IMediator _mediator;
		private readonly IPasswordHasher _passwordHasher;

		public UpdateUserCommand(
			IDbContext context,
			IMediator mediator,
			IPasswordHasher passwordHasher)
		{
			_context = context;
			_mediator = mediator;
			_passwordHasher = passwordHasher;
		}

		public async Task<Unit> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
		{
			var currentUser = await _context.Users
				.FindAsync(request.UserId)
				.ConfigureAwait(false);

			if (currentUser is null) throw new EntityNotFoundException("User");


			var password = currentUser.Password;
			if (!string.IsNullOrEmpty(request.Password))
				password = _passwordHasher.Create(request.Password);

			HashSet<Phone> phones = (HashSet<Phone>)currentUser.Phones;
			if (request.Phones.Any())
				phones = (HashSet<Phone>)request.Phones;

			currentUser.Update
			(
				request.FirstName ?? currentUser.FirstName,
				request.LastName ?? currentUser.LastName,
				request.UserName ?? currentUser.Username,
				request.Email ?? currentUser.Email,
				password,
				phones,
				currentUser.RefreshTokens,
				currentUser.Entries
			);


			await _context.SaveChangesAsync().ConfigureAwait(false);

			await _mediator.Publish(new UserUpdated { UserId = currentUser.UserId }, cancellationToken).ConfigureAwait(false);

			return Unit.Value;
		}
	}
}
