
using FluentValidation;

namespace Blog.Logic.UserAggregate.Commands.GenerateRefreshToken
{
	public class GenerateRefreshTokenRequestValidateCollection : AbstractValidator<GenerateRefreshTokenRequest>
	{
		public GenerateRefreshTokenRequestValidateCollection()
		{
			RuleFor(r => r.UserId).MinimumLength(6);
			RuleFor(r => r.ClientIp).Length(7, 16).Matches(".");
		}
	}
}