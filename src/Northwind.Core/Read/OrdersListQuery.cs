using System;
using System.Linq;

using NHibernate;
using NHibernate.Linq;

using Northwind.Core.Domain;

namespace Northwind.Core.Read
{
    public class OrdersListQuery : IQuery<OrdersListQuery.Criteria, PagedListResult<OrdersListQuery.Result>>
    {
        private readonly IStatelessSession session;

        public OrdersListQuery(IStatelessSession session)
        {
            this.session = session;
        }

        public PagedListResult<Result> Load(Criteria criteria)
        {
            var count = this.session.Query<Order>().Count(x => x.Employee.Id == criteria.EmployeeId);

            var result = new PagedListResult<Result>
            {
                TotalNumberOfItems = count,
                CurrentPage = criteria.CurrentPage,
                ItemsPerPage = criteria.ItemsPerPage
            };

            var items =
                this.session.Query<Domain.Order>()
                    .Where(x => x.Employee.Id == criteria.EmployeeId)
                    .OrderByDescending(x => x.OrderDate)
                    .Select(x => new Result { OrderId = x.Id, OrderDate = x.OrderDate, CustomerName = x.Customer.Name })
                    .Skip((result.CurrentPage - 1) * result.ItemsPerPage)
                    .Take(result.ItemsPerPage)
                    .ToList();

            result.Items = items;

            return result;
        }

        public class Criteria
        {
            public int EmployeeId { get; set; }

            public int ItemsPerPage { get; set; }

            public int CurrentPage { get; set; }
        }

        public class Result
        {
            public int OrderId { get; set; }

            public DateTime OrderDate { get; set; }

            public string CustomerName { get; set; }
        }
    }
}
