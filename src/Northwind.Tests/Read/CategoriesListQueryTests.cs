using System.Linq;

using Northwind.Read;

using Xunit;

namespace Northwind.Tests.Read
{
    public class CategoriesListQueryTests : AbstractIntegrationTestWithData
    {
        [Fact]
        public void Should_Return_Page_List_Of_Categories()
        {
            using (var session = SessionFactory.OpenSession())
            {
                var query = new CategoriesListQuery(session);
                var criteria = new PagedCriteria { CurrentPage = 1, ItemsPerPage = 5 };

                var result = query.Load(criteria);

                Assert.Equal(5, result.Items.Count());

                Assert.Equal(1, result.CurrentPage);
                Assert.Equal(5, result.ItemsPerPage);
                Assert.Equal(5, result.NumberOfItemsOnCurrentPage);
                Assert.Equal(2, result.TotalNumberOfPages);
                Assert.Equal(8, result.TotalNumberOfItems);
            }
        }
    }
}
