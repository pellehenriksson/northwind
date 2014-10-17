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
                new PersistenceSpecification<Supplier>(session)
                   .CheckProperty(x => x.Name, "some name")
                   .CheckProperty(x => x.Address, this.GetAddressForTest())
                   .CheckProperty(x => x.Phonenumber, this.GetPhonenumberForTest())
                   .VerifyTheMappings();
            }
        }
    }
}
