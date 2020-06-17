using Blog.Domain.Exceptions;
using Blog.Domain.ValueObjects;
using Blog.Logic.CrossCuttingConcerns.Interfaces;
using Blog.Logic.UserAggregate.Helpers;

using MediatR;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
			var currentToken = _context.RefreshTokens
				.FirstOrDefault(t => t.Token == request.CurrentRefreshToken);
			if (currentToken is null) throw new EntityNotFoundException("RefreshToken");


			var newRefreshToken = _tokenProvider.GenerateToken(request.ClientIp);

			var user = _context.Users
				.Single(u => u.RefreshTokens.Contains(currentToken));


			user.UpsertRefreshToken(newRefreshToken);
			await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

			return new UpdateRefreshTokenResponse
			{
				UserId = user.Id,
				RefreshToken = newRefreshToken.Token
			};
		}
	}
}
