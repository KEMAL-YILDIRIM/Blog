
using Blog.Logic.Validators;

using FluentValidation;

namespace Blog.Logic.EntryAggregate.Commands.CreateEntry
{
	public class UpdateEntryRequestValidationCollection : AbstractValidator<UpdateEntryRequest>
	{
		public UpdateEntryRequestValidationCollection()
		{
			RuleFor(x => x.EntryId).GreaterThan(0);
			RuleFor(x => x.Title).MinimumLength(3)
				.When(x => !string.IsNullOrEmpty(x.Title));
			RuleFor(x => x.Content).SetValidator(new ContentValidationCollection())
				.When(x => !string.IsNullOrEmpty(x.Title));
		}
	}
}
