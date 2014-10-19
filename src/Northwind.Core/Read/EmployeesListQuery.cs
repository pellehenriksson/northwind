using System.Linq;

using NHibernate;
using NHibernate.Linq;

using NLog.Interface;

using Northwind.Core.Domain;

namespace Northwind.Core.Read
{
    public class EmployeesListQuery : IQuery<EmployeesListQuery.Criteria, PagedListResult<EmployeesListQuery.Result>>
    {
        private readonly IStatelessSession session;

        private readonly ILogger logger;

        public EmployeesListQuery(IStatelessSession session, ILogger logger)
        {
            this.session = session;
            this.logger = logger;
        }

        public PagedListResult<Result> Load(Criteria criteria)
        {
            var count = this.session.Query<Employee>().Count();

            var result = new PagedListResult<Result> 
            {
                TotalNumberOfItems = count,
                CurrentPage = criteria.CurrentPage,
                ItemsPerPage = criteria.ItemsPerPage
            };

            var items =
                this.session.Query<Employee>()
                    .OrderBy(x => x.Name)
                    .Select(x => new Result { Id = x.Id, Title = x.Title, Name = x.Name })
                    .Skip((result.CurrentPage - 1) * result.ItemsPerPage)
                    .Take(result.ItemsPerPage)
                    .ToList();

            result.Items = items;

            return result;
        }
        
        public class Criteria
        {
            public int ItemsPerPage { get; set; }

            public int CurrentPage { get; set; }
        }

        public class Result
        {
            public int Id { get; set; }
            
            public string Title { get; set; }

            public string Name { get; set; }
        }
    }
}
