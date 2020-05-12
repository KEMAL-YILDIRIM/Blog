using Blog.Domain.AuditableEntities;
using Blog.Domain.ValueObjects;
using Blog.Logic.CrossCuttingConcerns.Interfaces;
using Blog.Logic.UserAggregate.Helpers;

using MediatR;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Logic.UserAggregate.Commands.CreateUser
{
	public class CreateUserCommand : IRequestHandler<CreateUserRequest>
	{
		private readonly IDbContext _context;
		private readonly IMediator _mediator;
		private readonly IPasswordHasher _passwordHasher;

		public CreateUserCommand(
			IDbContext context,
			IMediator mediator,
			IPasswordHasher passwordHasher)
		{
			_context = context;
			_mediator = mediator;
			_passwordHasher = passwordHasher;
		}

		public async Task<Unit> Handle(CreateUserRequest request, CancellationToken cancellationToken)
		{
			var entity = new User
			(
				request.FirstName,
				request.LastName,
				request.UserName,
				request.Email,
				_passwordHasher.Create(request.Password),
				(HashSet<Phone>)request.Phones,
				null
			); ;

			await _context.Users.AddAsync(entity).ConfigureAwait(false);
			await _context.SaveChangesAsync().ConfigureAwait(false);
			await _mediator.Publish(new UserCreated { UserId = entity.Id }, cancellationToken).ConfigureAwait(false);
			return Unit.Value;
		}
	}
}
