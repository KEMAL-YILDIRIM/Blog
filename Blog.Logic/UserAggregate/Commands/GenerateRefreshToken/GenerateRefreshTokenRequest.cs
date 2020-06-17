using Blog.Domain.ValueObjects;

using MediatR;

namespace Blog.Logic.UserAggregate.Commands.GenerateRefreshToken
{
	public class GenerateRefreshTokenRequest : IRequest<RefreshToken>
	{
		public string UserId { get; set; }
		public string ClientIp { get; set; }
	}
}