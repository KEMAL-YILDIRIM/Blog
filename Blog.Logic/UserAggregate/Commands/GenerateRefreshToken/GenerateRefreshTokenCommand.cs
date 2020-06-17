using Blog.Domain.Exceptions;
using Blog.Domain.ValueObjects;
using Blog.Logic.CrossCuttingConcerns.Interfaces;
using Blog.Logic.UserAggregate.Helpers;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

namespace Blog.Logic.UserAggregate.Commands.GenerateRefreshToken
{
	public class GenerateRefreshTokenCommand : IRequestHandler<GenerateRefreshTokenRequest, RefreshToken>
	{
		private readonly IDbContext _context;
		private readonly IMediator _mediator;
		private readonly ITokenProvider _tokenProvider;


		public GenerateRefreshTokenCommand(
			IDbContext context,
			ITokenProvider tokenProvider,
			IMediator mediator)
		{
			_context = context;
			_tokenProvider = tokenProvider;
			_mediator = mediator;
		}

		public async Task<RefreshToken> Handle(GenerateRefreshTokenRequest request, CancellationToken cancellationToken)
		{
			var user = _context.Users.Find(request.UserId);
			if (user is null) throw new EntityNotFoundException("User");

			var refreshToken = _tokenProvider.GenerateToken(request.ClientIp);

			user.UpsertRefreshToken(refreshToken);
			await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

			return refreshToken;
		}
	}
}
