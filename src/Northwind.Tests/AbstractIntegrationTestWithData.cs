using System.Configuration;
using System.Data;
using System.IO;

using NHibernate;

using NLog;
using NLog.Interface;

using Northwind.Core.Infrastructure.Persistance;

namespace Northwind.Tests
{
    /// <summary>
    /// Will build the database and load data from the original
    /// northwind database
    /// </summary>
    public abstract class AbstractIntegrationTestWithData
    {
        protected static readonly ISessionFactory SessionFactory;

        static AbstractIntegrationTestWithData()
        {
            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();

            var connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            var nhibernathHelper = new NHibernateHelper(connectionString);

            SessionFactory = nhibernathHelper.SessionFactory;

            nhibernathHelper.RebuildDatabase();

            LoadData();
        }

        protected ILogger Logger
        {
            get
            {
                return new LoggerAdapter(LogManager.GetLogger(this.GetType().Name));
            }
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
