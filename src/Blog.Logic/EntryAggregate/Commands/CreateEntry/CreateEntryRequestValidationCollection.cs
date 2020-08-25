
using Blog.Logic.Validators;

using FluentValidation;

namespace Blog.Logic.EntryAggregate.Commands.CreateEntry
{
	public class CreateEntryRequestValidationCollection : AbstractValidator<CreateEntryRequest>
	{
		public CreateEntryRequestValidationCollection()
		{
			RuleFor(x => x.Title).MinimumLength(3).NotEmpty();
			RuleFor(x => x.Content).SetValidator(new ContentValidationCollection());
		}
	}
}
