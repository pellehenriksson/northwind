using Ninject.Modules;

using Northwind.Core.Read;

namespace Northwind.Core.Infrastructure.Dependencies
{
    public class ReadModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IQueryRepository>().To<QueryRepository>();
        }
    }
}
