using System.Collections.Generic;
using System.Linq;

using NHibernate;
using NHibernate.Linq;

using NLog.Interface;

using Northwind.Core.Domain;

namespace Northwind.Core.Read
{
    public class EmployeesListQuery : IQuery<EmployeesListQuery.Criteria, IList<EmployeesListQuery.Result>>
    {
        private readonly IStatelessSession session;

        private readonly ILogger logger;

        public EmployeesListQuery(IStatelessSession session, ILogger logger)
        {
            this.session = session;
            this.logger = logger;
        }

        public IList<Result> Load(Criteria criteria)
        {
            this.logger.Debug("Building query");

            var query = from e in this.session.Query<Employee>()
                        orderby e.Name
                        select new Result
                        {
                            Id = e.Id, 
                            Title = e.Title,
                            Name = e.Name
                        };

            this.logger.Debug("Executing query");

            var result = query.ToList();

            this.logger.Debug("Found: {0} matches", result.Count);

            return result;
        }
        
        public class Criteria
        {
        }

        public class Result
        {
            public int Id { get; set; }
            
            public string Title { get; set; }

            public string Name { get; set; }
        }
    }
}
