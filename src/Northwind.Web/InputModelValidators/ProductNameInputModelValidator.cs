using System.Linq;

using FluentValidation;

using NHibernate;
using NHibernate.Linq;

using Northwind.Core.Domain;
using Northwind.Web.InputModels;

namespace Northwind.Web.InputModelValidators
{
    public class ProductNameInputModelValidator : AbstractValidator<ProductNameInputModel>
    {
        private readonly ISession session;

        public ProductNameInputModelValidator(ISession session)
        {
            this.session = session;

            this.RuleFor(x => x.Name).Length(1, 40);
            this.RuleFor(x => x.Name)
                    .Must((model, s) => this.session.Query<Product>().Any(x => x.Name == model.Name && x.Id != model.Id) == false)
                    .WithMessage("Product name must be unique");
        }
    }
}