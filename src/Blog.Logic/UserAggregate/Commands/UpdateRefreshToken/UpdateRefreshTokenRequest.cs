
using MediatR;

namespace Blog.Logic.UserAggregate.Commands.UpdateRefreshToken
{
	public class UpdateRefreshTokenRequest : IRequest<UpdateRefreshTokenResponse>
	{
		public string ClientIp { get; set; }
		public string CurrentRefreshToken { get; set; }
	}
}