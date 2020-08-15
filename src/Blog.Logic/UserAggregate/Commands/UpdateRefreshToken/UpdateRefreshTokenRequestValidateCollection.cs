
using FluentValidation;

namespace Blog.Logic.UserAggregate.Commands.UpdateRefreshToken
{
	public class UpdateRefreshTokenRequestValidateCollection : AbstractValidator<UpdateRefreshTokenRequest>
	{
		public UpdateRefreshTokenRequestValidateCollection()
		{
			RuleFor(r => r.CurrentRefreshToken).NotEmpty().MinimumLength(6);
			RuleFor(r => r.ClientIp).NotEmpty().Length(7, 16).Matches(".");
		}
	}
}