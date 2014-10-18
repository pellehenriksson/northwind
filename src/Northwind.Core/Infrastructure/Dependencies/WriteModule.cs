using Ninject.Modules;

using Northwind.Core.Common;
using Northwind.Core.Write;

namespace Northwind.Core.Infrastructure.Dependencies
{
    public class WriteModule : NinjectModule
    {
        public override void Load()
        {
           this.Bind<ICommandInvoker>().To<CommandInvoker>();
           this.BindCommandHandlers();
        }

        private void BindCommandHandlers()
        {
            this.GetType()
                .Assembly.GetAllTypesImplementingInterface(typeof(ICommandHandler<>))
                .ForEach(match => this.Bind(match.Interface).To(match.ConcreteType));
        }
    }
}
