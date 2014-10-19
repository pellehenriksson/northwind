using System;

using FluentNHibernate.Testing;

using Northwind.Core.Domain;

using Xunit;

namespace Northwind.Tests.Core.Infrastructure.Persistance.Mappings
{
    public class EmployeeMapTests : AbstractIntegrationTest
    {
        [Fact]
        public void Should_Map_Employee()
        {
            var boss = Employee.Create("Michael Scott", new DateTime(1960, 1, 1), DateTime.Today.AddYears(-10));
            boss.ChangeTitle("Regionl Manager");
 
            using (var session = SessionFactory.OpenSession())
            {
                session.Save(boss);
            }

            using (var session = SessionFactory.OpenSession())
            {
                new PersistenceSpecification<Employee>(session)
                    .CheckProperty(x => x.Name, "some name")
                    .CheckProperty(x => x.Title, "some description")
                    .CheckProperty(x => x.DayOfBirth, DateTime.Today)
                    .CheckProperty(x => x.HiredDate, DateTime.Today)
                    .CheckProperty(x => x.Address, this.GetAddressForTest())
                    .CheckProperty(x => x.Notes, "some note")
                    .CheckReference(x => x.ReportsTo, boss, e => e.ReportsTo.Id == boss.Id)
                    .VerifyTheMappings();
            }
        }
    }
}
