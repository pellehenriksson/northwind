using System.Configuration;

using NHibernate;

using Northwind.Core.Domain;
using Northwind.Core.Infrastructure.Persistance;

namespace Northwind.Tests
{
    public abstract class AbstractIntegrationTestBase
    {
        protected static readonly ISessionFactory SessionFactory;

        private static readonly NHibernateHelper NHibernathHelper;

        static AbstractIntegrationTestBase()
        {
            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();

            var connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            NHibernathHelper = new NHibernateHelper(connectionString);

            SessionFactory = NHibernathHelper.SessionFactory;
        }

        protected AbstractIntegrationTestBase()
        {
            NHibernathHelper.RebuildDatabase();
        }

        protected Phonenumber GetPhonenumberForTest()
        {
            return new Phonenumber("home", "0470-81787");
        }

        protected Address GetAddressForTest()
        {
            return new Address("Slupvägen 11", "353 55", "Växjö", "Småland", "Sverige");
        }
    }
}
