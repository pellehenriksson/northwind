using FluentNHibernate.Testing;

using Northwind.Core.Domain;

using Xunit;

namespace Northwind.Tests.Core.Infrastructure.Persistance.Mappings
{
    public class ShipperMapTests : AbstractIntegrationTestBase
    {
        [Fact]
        public void Should_Map_Shipper()
        {
            using (var session = SessionFactory.OpenSession())
            {
                var phone = new Phonenumber("extension", "12345");
                
                new PersistenceSpecification<Shipper>(session)
                   .CheckProperty(x => x.Name, "some name")
                   .VerifyTheMappings();
            }
        }
    }
}
