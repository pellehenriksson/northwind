using System.Configuration;

using NHibernate;

using Ninject;
using Ninject.Modules;

using NLog;
using NLog.Interface;

using Northwind.Core.Infrastructure.Persistance;

namespace Northwind.Core.Infrastructure.Dependencies
{
    public class CommonModule : NinjectModule
    {
        public override void Load()
        {
            if (ConfigurationManager.ConnectionStrings["northwind"] == null)
            {
                throw new ConfigurationErrorsException("No northwind connectionstring defined");
            }

            var connectionString = ConfigurationManager.ConnectionStrings["northwind"].ConnectionString;

            var helper = new NHibernateHelper(connectionString);

            this.Bind<ISessionFactory>().ToConstant(helper.SessionFactory).InSingletonScope();
            
            this.Bind<ISession>().ToMethod(x => x.Kernel.Get<ISessionFactory>().OpenSession());

            this.Bind<IStatelessSession>().ToMethod(x => x.Kernel.Get<ISessionFactory>().OpenStatelessSession());
            
            this.Bind<ILogger>().ToMethod(x => new LoggerAdapter(LogManager.GetLogger(x.Request.Target.Member.DeclaringType.FullName)));
        }
    }
}
