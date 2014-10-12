using System;
using System.Globalization;
using System.Reflection;

using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

using NHibernate;
using NHibernate.Tool.hbm2ddl;

using Northwind.Core.Common;

namespace Northwind.Core.Infrastructure.Persistance
{
    public class NHibernateHelper
    {
        private readonly string connectionString;

        private ISessionFactory sessionFactory;

        public NHibernateHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public ISessionFactory SessionFactory
        {
            get
            {
                return this.sessionFactory ?? (this.sessionFactory = this.CreateSessionFactory());
            }
        }

        public NHibernate.Cfg.Configuration Configuration { get; private set; }

        public void RebuildDatabase()
        {
            var exporter = new SchemaExport(this.Configuration);
            exporter.Create(false, true);
        }

        private ISessionFactory CreateSessionFactory()
        {
            var factory =
                Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2008.ConnectionString(this.connectionString))
                    .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                    .Mappings(m => m.HbmMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                    .ExposeConfiguration(this.OnConfig)
                    .BuildSessionFactory();

            if (AppSettingsHelper.GetValue("northwind.db.updateschema", false))
            {
                this.UpdateDatabaseSchema();
                this.ExecuteScripts(factory);
            }

            return factory;
        }
        
        private void UpdateDatabaseSchema()
        {
            var updater = new SchemaUpdate(this.Configuration);
            updater.Execute(false, true);

            if (updater.Exceptions.Count > 0)
            {
                throw new SystemException("Failed to update database schema", updater.Exceptions[0]);
            }
        }

        private void ExecuteScripts(ISessionFactory factory)
        {
            using (var session = factory.OpenSession())
            {
            }
        }

        private void OnConfig(NHibernate.Cfg.Configuration cfg)
        {
            this.Configuration = cfg;

            var useProfiler = AppSettingsHelper.GetValue("northwind.db.useprofiler", false);
            this.Configuration.SetProperty("generate_statistics", useProfiler.ToString(CultureInfo.InvariantCulture));

            if (useProfiler)
            {
                HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
            }
        }
    }
}
