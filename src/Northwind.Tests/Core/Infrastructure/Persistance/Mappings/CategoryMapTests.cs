using FluentNHibernate.Testing;

using Northwind.Core.Domain;

using Xunit;

namespace Northwind.Tests.Core.Infrastructure.Persistance.Mappings
{
    public class CategoryMapTests : AbstractIntegrationTest
    {
        [Fact]
        public void Should_Map_Category()
        {
            using (var session = SessionFactory.OpenSession())
            {
                new PersistenceSpecification<Category>(session)
                   .CheckProperty(x => x.Name, "name")
                   .CheckProperty(x => x.Description, "description")
                   .VerifyTheMappings();
            }
        }
    }
}
