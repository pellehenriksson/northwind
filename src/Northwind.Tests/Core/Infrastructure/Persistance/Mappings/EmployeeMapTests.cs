using System;

using FluentNHibernate.Testing;

using Northwind.Core.Domain;

using Xunit;

namespace Northwind.Tests.Core.Infrastructure.Persistance.Mappings
{
    public class EmployeeMapTests : AbstractIntegrationTestBase
    {
        [Fact(Skip = "figure out whats wrong")]
        public void Should_Map_Employee()
        {
            var boss = Employee.Create("Michael Scott");
            boss.ChangeTitle("Regionl Manager");
            boss.ChangeDayOfBirth(new DateTime(1960, 1, 1));
            boss.ChangeHiredDate(DateTime.Today.AddYears(-10));
 
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
                   // .CheckProperty(x => x.Address, this.GetAddressForTest())
                    .CheckProperty(x => x.Notes, "some note")
                    .CheckReference(x => x.ReportsTo, boss, e => e.ReportsTo.Id == boss.Id)
                  .VerifyTheMappings();
            }
        }
    }
}
