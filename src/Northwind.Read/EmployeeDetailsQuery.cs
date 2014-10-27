using System;
using System.Linq;

using NHibernate;
using NHibernate.Linq;

using NLog.Interface;

using Northwind.Core.Domain;

namespace Northwind.Read
{
    public class EmployeeDetailsQuery : IQuery<EmployeeDetailsQuery.Criteria, EmployeeDetailsQuery.Result>
    {
        private readonly ISession session;

        private readonly ILogger logger;

        public EmployeeDetailsQuery(ISession session, ILogger logger)
        {
            this.session = session;
            this.logger = logger;
        }

        public Result Load(Criteria criteria)
        {
            this.logger.Debug("Building query for id: '{0}'", criteria.Id);
            
            var query = from e in this.session.Query<Employee>() 
                        where e.Id == criteria.Id 
                        select new Result
                            {
                                Id = e.Id,
                                Title = e.Title,
                                Name = e.Name,
                                DayOfBirth = e.DayOfBirth,
                                HireDate = e.HiredDate,
                                Notes = e.Notes,
                                AddressStreet = e.Address.Street,
                                AddressPostalCode = e.Address.PostalCode,
                                AddressCity = e.Address.City,
                                AddressRegion = e.Address.Region,
                                AddressCountry = e.Address.Country,
                                ReportsToId = e.ReportsTo == null ? -1 : e.ReportsTo.Id,
                                ReportsToName = e.ReportsTo == null ? string.Empty : e.ReportsTo.Name
                            };
           
            this.logger.Debug("Executing query");

            var result = query.FirstOrDefault();

            this.logger.Debug("Found match: '{0}'", result != null);

            return result;
        }

        public class Criteria
        {
            public int Id { get; set; }
        }

        public class Result
        {
            public int Id { get; set; }

            public string Title { get; set; }

            public string Name { get; set; }

            public DateTime DayOfBirth { get; set; }

            public DateTime HireDate { get; set; }

            public string AddressStreet { get; set; }

            public string AddressPostalCode { get; set; }

            public string AddressCity { get; set; }

            public string AddressRegion { get; set; }

            public string AddressCountry { get; set; }

            public string Notes { get; set; }

            public int ReportsToId { get; set; }

            public string ReportsToName { get; set; }
        }
    }
}
