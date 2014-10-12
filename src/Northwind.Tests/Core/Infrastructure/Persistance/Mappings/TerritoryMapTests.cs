using FluentNHibernate.Testing;

using Northwind.Core.Domain;

using Xunit;

namespace Northwind.Tests.Core.Infrastructure.Persistance.Mappings
{
    public class TerritoryMapTests : AbstractIntegrationTestBase
    {
        [Fact]
        public void Should_Map_Territory()
        {
            var region = new Region { Name = "some region" };
            
            using (var session = SessionFactory.OpenSession())
            {
                session.Save(region);
            }

            using (var session = SessionFactory.OpenSession())
            {
                new PersistenceSpecification<Territory>(session)
                   .CheckProperty(x => x.Name, "some name")
                   .CheckReference(x => x.Region, region, r => r.Id == region.Id)
                   .VerifyTheMappings();
            }
        }
    }
}
