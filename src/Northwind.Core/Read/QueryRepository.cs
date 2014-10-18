using System;

using Ninject;

namespace Northwind.Core.Read
{
    public class QueryRepository : IQueryRepository
    {
        private readonly IKernel kernel;

        public QueryRepository(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public TOutput Load<TInput, TOutput>(TInput input)
        {
            var factory = this.kernel.TryGet<IQuery<TInput, TOutput>>();

            if (factory == null)
            {
                throw new SystemException(string.Format("Unable to resolve view factory for Input: {0} Output: {1}", typeof(TInput).Name, typeof(TOutput).Name));
            }

            return factory.Load(input);
        }
    }
}
