
using Blog.Domain.PropertyEntities;

using FluentValidation;

namespace Blog.Logic.Validators
{
	public class CategoryValidationCollection : AbstractValidator<Category>
	{
		public CategoryValidationCollection()
		{
			RuleFor(x => x.Name).MinimumLength(3).NotEmpty();
		}
	}
}
