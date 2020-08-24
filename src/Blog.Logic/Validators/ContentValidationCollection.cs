
using Blog.Domain.AuditableEntities;

using FluentValidation;

namespace Blog.Logic.Validators
{
	public class ContentValidationCollection : AbstractValidator<Content>
	{
		public ContentValidationCollection()
		{
			RuleFor(x => x.Html).MinimumLength(5).NotEmpty();
		}
	}
}
