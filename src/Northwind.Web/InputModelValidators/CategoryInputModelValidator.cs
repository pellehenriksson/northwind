using System.Linq;

using FluentValidation;

using NHibernate;
using NHibernate.Linq;

using Northwind.Core.Domain;
using Northwind.Web.InputModels;

namespace Northwind.Web.InputModelValidators
{
    public class CategoryInputModelValidator : AbstractValidator<CategoryInputModel>
    {
        private readonly ISession session;

        public CategoryInputModelValidator(ISession session)
        {
            this.session = session;
        }

        public CategoryInputModelValidator()
        {
            this.RuleFor(x => x.Name).NotEmpty().Length(1, 50);
            this.RuleFor(x => x.Name)
                .Must((model, s) => this.session.Query<Category>().Any(x => x.Name == model.Name && x.Id != model.Id) == false)
                .WithMessage("Category name must be unique");
        }
    }
}