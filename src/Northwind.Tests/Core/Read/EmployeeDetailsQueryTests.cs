﻿using Northwind.Core.Read;

using Xunit;

namespace Northwind.Tests.Core.Read
{
    public class EmployeeDetailsQueryTests : AbstractIntegrationTestWithDataBase
    {
        [Fact]
        public void Should_Return_Details_For_Employee()
        {
            using (var session = SessionFactory.OpenStatelessSession())
            {
                var query = new EmployeeDetailsQuery(session, this.Logger);
                var result = query.Load(new EmployeeDetailsQuery.Criteria { Id = 1 });
                
                Assert.NotNull(result);
            }
        }

        [Fact]
        public void Should_Return_Null_When_No_Employee_Found()
        {
            using (var session = SessionFactory.OpenStatelessSession())
            {
                var query = new EmployeeDetailsQuery(session, this.Logger);
                var result = query.Load(new EmployeeDetailsQuery.Criteria { Id = -1 });

                Assert.Null(result);
            }
        }
    }
}
