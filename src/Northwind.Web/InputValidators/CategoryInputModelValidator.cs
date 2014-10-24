using FluentValidation;

using Northwind.Web.InputModels;

namespace Northwind.Web.InputValidators
{
    public class CategoryInputModelValidator : AbstractValidator<CategoryInputModel>
    {
        public CategoryInputModelValidator()
        {
            this.RuleFor(x => x.Name).NotEmpty().Length(1, 50);
        }
    }
}