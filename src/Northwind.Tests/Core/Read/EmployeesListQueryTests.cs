using Northwind.Core.Read;

using Xunit;

namespace Northwind.Tests.Core.Read
{
    public class EmployeesListQueryTests : AbstractIntegrationTestWithDataBase
    {
        [Fact]
        public void Should_Return_List_Of_Employees()
        {
            using (var session = SessionFactory.OpenStatelessSession())
            {
                var query = new EmployeesListQuery(session, this.Logger);
                var result = query.Load(new EmployeesListQuery.Criteria());

                Assert.Equal(9, result.Count);
            }
        }
    }
}
