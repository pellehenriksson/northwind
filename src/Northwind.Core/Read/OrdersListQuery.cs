using System;
using System.Collections.Generic;
using System.Linq;

using NHibernate;
using NHibernate.Linq;

using NLog.Interface;

namespace Northwind.Core.Read
{
    public class OrdersListQuery : IQuery<OrdersListQuery.Criteria, IList<OrdersListQuery.Result>>
    {
        private readonly IStatelessSession session;

        private readonly ILogger logger;

        public OrdersListQuery(IStatelessSession session, ILogger logger)
        {
            this.session = session;
            this.logger = logger;
        }

        public IList<Result> Load(Criteria criteria)
        {
            this.logger.Debug("Building query for employee id: '{0}'", criteria.EmployeeId);

            var result =
                this.session.Query<Domain.Order>()
                    .Where(x => x.Employee.Id == criteria.EmployeeId)
                    .OrderByDescending(x => x.OrderDate)
                    .Select(x => new Result { OrderId = x.Id, OrderDate = x.OrderDate, CustomerName = x.Customer.Name })
                    .Take(20)
                    .ToList();

            this.logger.Debug("Found: {0} matches", result.Count);
            
            return result;
        }

        public class Criteria
        {
            public int EmployeeId { get; set; }
        }

        public class Result
        {
            public int OrderId { get; set; }

            public DateTime OrderDate { get; set; }

            public string CustomerName { get; set; }
        }
    }
}
