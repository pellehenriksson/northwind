using FluentNHibernate.Testing;

using Northwind.Core.Domain;

using Xunit;

namespace Northwind.Tests.Core.Infrastructure.Persistance.Mappings
{
    public class SupplierMapTests : AbstractIntegrationTestBase
    {
        [Fact]
        public void Should_Map_Supplier()
        {
            using (var session = SessionFactory.OpenSession())
            {
                var address = new Address
                {
                    Street = "way 1",
                    PostalCode = "666",
                    City = "tinseltown",
                    Region = "south of",
                    Country = "heaven"
                };

                var phone = new Phonenumber("extension", "12345");
                
                new PersistenceSpecification<Supplier>(session)
                   .CheckProperty(x => x.Name, "some name")
                   .CheckProperty(x => x.Address, address)
                   .CheckProperty(x => x.Phonenumber, phone)
                   .VerifyTheMappings();
            }
        }
    }
}
