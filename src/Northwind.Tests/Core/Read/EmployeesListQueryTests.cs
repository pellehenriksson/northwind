using System;

using Northwind.Core.Read;

using Xunit;

namespace Northwind.Tests.Core.Read
{
    public class EmployeesListQueryTests : AbstractIntegrationTestWithData
    {
        [Fact]
        public void Should_Return_List_Of_Employees()
        {
            using (var session = SessionFactory.OpenStatelessSession())
            {
                var query = new EmployeesListQuery(session, this.Logger);

                var criteria = new EmployeesListQuery.Criteria { CurrentPage = 1, ItemsPerPage = 50 };

                var result = query.Load(criteria);

                Console.Out.WriteLine(result.TotalNumberOfItems);
                Console.Out.WriteLine(result.CurrentPage);
                Console.Out.WriteLine(result.ItemsPerPage);
                Console.Out.WriteLine(result.TotalNumberOfPages);
            }
        }
    }
}
