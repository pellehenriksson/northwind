using System.Linq;

using Northwind.Read;

using Xunit;

namespace Northwind.Tests.Read
{
    public class EmployeesListQueryTests : AbstractIntegrationTestWithData
    {
        [Fact]
        public void Should_Return_Paged_List_Of_Employees()
        {
            using (var session = SessionFactory.OpenSession())
            {
                var query = new EmployeesListQuery(session, this.Logger);
                var criteria = new EmployeesListQuery.Criteria { CurrentPage = 1, ItemsPerPage = 50 };

                var result = query.Load(criteria);

                Assert.Equal(9, result.Items.Count());

                Assert.Equal(1, result.CurrentPage);
                Assert.Equal(50, result.ItemsPerPage);
                Assert.Equal(9, result.NumberOfItemsOnCurrentPage);
                Assert.Equal(1, result.TotalNumberOfPages);
                Assert.Equal(9, result.TotalNumberOfItems);
            }
        }
    }
}
