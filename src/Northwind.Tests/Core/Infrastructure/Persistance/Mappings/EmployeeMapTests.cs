using System;

using FluentNHibernate.Testing;

using Northwind.Core.Domain;

using Xunit;

namespace Northwind.Tests.Core.Infrastructure.Persistance.Mappings
{
    public class EmployeeMapTests : AbstractIntegrationTestBase
    {
        [Fact]
        public void Should_Map_Employee()
        {
            var boss = new Employee { Name = "a", Title = "boss", Born = DateTime.Today, Hired = DateTime.Today };

            using (var session = SessionFactory.OpenSession())
            {
                session.Save(boss);
            }

            using (var session = SessionFactory.OpenSession())
            {
                var phone = new Phonenumber("extension", "12345");
               
                var address = new Address
                {
                    Street = "way 1",
                    PostalCode = "666",
                    City = "tinseltown",
                    Region = "south of",
                    Country = "heaven"
                };

                new PersistenceSpecification<Employee>(session)
                  .CheckProperty(x => x.Name, "some name")
                  .CheckProperty(x => x.Title, "some description")
                  .CheckProperty(x => x.DayOfBirth, DateTime.Today)
                  .CheckProperty(x => x.HiredDate, DateTime.Today)
                  //.CheckProperty(x => x.Address, address)
                  .CheckProperty(x => x.Notes, "some note")
                  .CheckReference(x => x.ReportsTo, boss, e => e.ReportsTo.Id == boss.Id)

                  .VerifyTheMappings();
            }
        }
    }
}
