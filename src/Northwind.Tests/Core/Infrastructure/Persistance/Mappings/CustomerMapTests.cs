using FluentNHibernate.Testing;

using Northwind.Core.Domain;

using Xunit;

namespace Northwind.Tests.Core.Infrastructure.Persistance.Mappings
{
    public class CustomerMapTests : AbstractIntegrationTestBase
    {
        [Fact]
        public void Should_Map_Customer()
        {
            using (var session = SessionFactory.OpenSession())
            {
                new PersistenceSpecification<Customer>(session)
                 .CheckProperty(x => x.Name, "name")
                 .CheckProperty(x => x.Contact, "nisse hult")
                 //.CheckProperty(x => x.Address, this.GetAddressForTest())
                 //.CheckProperty(x => x.Phonenumber, this.GetPhonenumberForTest())
                 .VerifyTheMappings();
            }
        }
    }
}
