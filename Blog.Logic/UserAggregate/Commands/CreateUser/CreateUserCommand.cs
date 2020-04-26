using Blog.Domain.AuditableEntities;
using Blog.Logic.Common.Interfaces;

using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Logic.UserAggregate.Commands.CreateUser
{
	public class CreateUserCommand : IRequestHandler<CreateUserRequest>
	{
		private readonly IDbContext _context;
		private readonly ICurrentUserService _userService;
		private readonly IMediator _mediator;

		public CreateUserCommand(
			IDbContext context,
			ICurrentUserService userService,
			IMediator mediator)
		{
			_context = context;
			_userService = userService;
			_mediator = mediator;
		}

		public async Task<Unit> Handle(CreateUserRequest request, CancellationToken cancellationToken)
		{
			var entity = new User
			(
				request.FullName,
				request.Email,
				request.Password,
				request.Phones.ToList()
			);

			await _context.Users.AddAsync(entity);
			await _mediator.Publish(new UserCreated { UserId = entity.Id }, cancellationToken).ConfigureAwait(false);
			return Unit.Value;
		}
	}
}
