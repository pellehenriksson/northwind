using System.Linq;

using Northwind.Core.Read;

using Xunit;

namespace Northwind.Tests.Core.Read
{
    public class OrdersListQueryTests : AbstractIntegrationTestWithData
    {
        [Fact]
        public void Should_Return_List_Of_Orders_For_Empployee()
        {
            using (var session = SessionFactory.OpenStatelessSession())
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
