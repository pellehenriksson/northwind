using System.Linq;

using Northwind.Read;

using Xunit;

namespace Northwind.Tests.Read
{
    public class OrdersListQueryTests : AbstractIntegrationTestWithData
    {
        [Fact]
        public void Should_Return_Paged_List_Of_Orders_For_Empployee()
        {
            using (var session = SessionFactory.OpenSession())
            {
                var query = new OrdersListQuery(session);
                var criteria = new OrdersListQuery.Criteria { EmployeeId = 1, CurrentPage = 2, ItemsPerPage = 50 };

                var result = query.Load(criteria);

                Assert.Equal(50, result.Items.Count());

                Assert.Equal(2, result.CurrentPage);
                Assert.Equal(50, result.ItemsPerPage);
                Assert.Equal(50, result.NumberOfItemsOnCurrentPage);
                Assert.Equal(3, result.TotalNumberOfPages);
                Assert.Equal(123, result.TotalNumberOfItems);
            }
        }
    }
}
