using FluentNHibernate.Testing;

using Northwind.Core.Domain;

using Xunit;

namespace Northwind.Tests.Core.Infrastructure.Persistance.Mappings
{
    public class RegionMapTests : AbstractIntegrationTest
    {
        [Fact]
        public void Should_Map_Region()
        {
            using (var session = SessionFactory.OpenSession())
            {
                new PersistenceSpecification<Region>(session)
                   .CheckProperty(x => x.Name, "some name")
                   .VerifyTheMappings();
            }
        }
    }
}
