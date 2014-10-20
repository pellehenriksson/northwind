using System;

using FluentValidation;

using Ninject;

namespace Northwind.Web.Infrastructure.Dependencies
{
    public class NinjectFluentValidationValidatorFactory : ValidatorFactoryBase
    {
        private readonly IKernel kernel;

        public NinjectFluentValidationValidatorFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            var validator = this.kernel.TryGet(validatorType) as IValidator;
            return validator;
        }
    }
}