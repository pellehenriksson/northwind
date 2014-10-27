using FluentValidation;

using Ninject.Modules;

using Northwind.Web.InputModelValidators;

namespace Northwind.Web.Infrastructure.Dependencies
{
    public class WebModule : NinjectModule
    {
        public override void Load()
        {
            AssemblyScanner.FindValidatorsInAssemblyContaining<CategoryInputModelValidator>().ForEach(match => this.Bind(match.InterfaceType).To(match.ValidatorType));
        }
    }
}