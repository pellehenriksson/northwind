using Ninject.Modules;

using Northwind.Core.Common;

namespace Northwind.Read.Infrastructure
{
    public class ReadModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IQueryRepository>().To<QueryRepository>();
            this.BindQueryFactories();
        }

        private void BindQueryFactories()
        {
            this.GetType()
                .Assembly.GetAllTypesImplementingInterface(typeof(IQuery<,>))
                .ForEach(match => this.Bind(match.Interface).To(match.ConcreteType));
        }
    }
}
