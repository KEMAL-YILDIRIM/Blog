using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Blog.Logic.CrossCuttingConcerns.Interfaces;
using Blog.Logic.UserAggregate.Helpers;

using MediatR;

namespace Blog.Logic.UserAggregate.Commands.UpdateRefreshToken
{
	public class UpdateRefreshTokenCommand : IRequestHandler<UpdateRefreshTokenRequest, UpdateRefreshTokenResponse>
	{
		private readonly IDbContext _context;
		private readonly IMediator _mediator;
		private readonly ITokenProvider _tokenProvider;


		public UpdateRefreshTokenCommand(
			IDbContext context,
			ITokenProvider tokenProvider,
			IMediator mediator)
		{
			_context = context;
			_tokenProvider = tokenProvider;
			_mediator = mediator;
		}

		public async Task<UpdateRefreshTokenResponse> Handle(UpdateRefreshTokenRequest request, CancellationToken cancellationToken)
		{
			var user = _context.Users
				.AsEnumerable()
				.Single(u => u.RefreshTokens.Any(e => e.Token == request.CurrentRefreshToken));

			var newRefreshToken = _tokenProvider.GenerateToken(request.ClientIp);
			user.UpsertRefreshToken(newRefreshToken);
			await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

			return new UpdateRefreshTokenResponse
			{
				UserId = user.UserId,
				RefreshToken = newRefreshToken.Token
			};
		}
	}
}
