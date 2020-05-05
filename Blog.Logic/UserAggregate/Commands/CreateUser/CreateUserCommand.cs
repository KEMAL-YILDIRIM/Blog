using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Blog.Domain.AuditableEntities;
using Blog.Logic.CrossCuttingConcerns.Interfaces;
using Blog.Logic.UserAggregate.Helpers;

using MediatR;

namespace Blog.Logic.UserAggregate.Commands.CreateUser
{
	public class CreateUserCommand : IRequestHandler<CreateUserRequest>
	{
		private readonly IDbContext _context;
		private readonly ICurrentUserService _userService;
		private readonly IMediator _mediator;
		private readonly IPasswordHasher _passwordHasher;

		public CreateUserCommand(
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

		public async Task<Unit> Handle(CreateUserRequest request, CancellationToken cancellationToken)
		{
			var entity = new User
			(
				request.FullName,
				request.Email,
				_passwordHasher.Create(request.Password),
				request.Phones.ToList(),
				null
			);

			await _context.Users.AddAsync(entity).ConfigureAwait(false);
			await _mediator.Publish(new UserCreated { UserId = entity.Id }, cancellationToken).ConfigureAwait(false);
			return Unit.Value;
		}
	}
}
