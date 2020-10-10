using Blog.Logic.Validators;

using FluentValidation;

namespace Blog.Logic.UserAggregate.Commands.CreateUser
{
	public class UpdateUserRequestValidateCollection : AbstractValidator<UpdateUserRequest>
	{
		public UpdateUserRequestValidateCollection(
			IPasswordValidator passwordValidator,
			IEmailValidator emailValidator)
		{
			RuleFor(x => x.UserName).MinimumLength(3);
			RuleFor(x => x.FirstName).MinimumLength(3);
			RuleFor(x => x.LastName).MinimumLength(3);
			RuleFor(x => x.Email).EmailAddress().Must(emailValidator.IsValid).NotEmpty();
			RuleFor(x => x.Password).Must(passwordValidator.Validate);
		}
	}
}
