
using FluentValidation;

namespace Blog.Logic.UserAggregate.Commands.GenerateRefreshToken
{
	public class GenerateRefreshTokenRequestValidateCollection : AbstractValidator<GenerateRefreshTokenRequest>
	{
		public GenerateRefreshTokenRequestValidateCollection()
		{
			RuleFor(r => r.UserId).NotEmpty().MinimumLength(6);
			RuleFor(r => r.ClientIp).NotEmpty().Length(7, 16).Matches(".");
		}
	}
}