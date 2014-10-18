using System.Configuration;
using System.Data;
using System.IO;

using NHibernate;

using Northwind.Core.Infrastructure.Persistance;

namespace Northwind.Tests
{
    /// <summary>
    /// Will build the database and load data from the original
    /// northwind database
    /// </summary>
    public abstract class AbstractIntegrationTestsWithDataBase
    {
        protected static readonly ISessionFactory SessionFactory;

        private static readonly NHibernateHelper NHibernathHelper;

        static AbstractIntegrationTestsWithDataBase()
        {
            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();

            var connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            NHibernathHelper = new NHibernateHelper(connectionString);

            SessionFactory = NHibernathHelper.SessionFactory;

            NHibernathHelper.RebuildDatabase();

            LoadData();
        }

        private static void LoadData()
        {
            using (var session = SessionFactory.OpenSession())
            using (var tx = session.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                var sql = File.ReadAllText(@"..\..\..\..\scripts\import-data-from-northwind.sql");

                var query = session.CreateSQLQuery(sql);
                query.ExecuteUpdate();

                tx.Commit();
            }
        }
    }
}
