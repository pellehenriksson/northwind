using Ninject;

namespace Northwind.Core.Write
{
    public class CommandInvoker : ICommandInvoker
    {
        private readonly IKernel kernel;

        public CommandInvoker(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public void Execute<T>(T command)
        {
            var handler = this.kernel.Get<ICommandHandler<T>>();
            handler.Handle(command);
        }
    }
}