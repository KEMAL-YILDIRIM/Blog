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
			RuleFor(x => x.UserId).MinimumLength(8).NotEmpty();
			RuleFor(x => x.UserName).MinimumLength(3)
				.When(x => !string.IsNullOrEmpty(x.UserName)); ;
			RuleFor(x => x.FirstName).MinimumLength(3)
				.When(x => !string.IsNullOrEmpty(x.FirstName)); ;
			RuleFor(x => x.LastName).MinimumLength(3)
				.When(x => !string.IsNullOrEmpty(x.LastName)); ;
			RuleFor(x => x.Email).EmailAddress().Must(emailValidator.IsValid)
				.When(x => !string.IsNullOrEmpty(x.Email));
			RuleFor(x => x.Password).Must(passwordValidator.Validate)
				.When(x => !string.IsNullOrEmpty(x.Password));
		}
	}
}
