using FluentNHibernate.Testing;

using Northwind.Core.Domain;

using Xunit;

namespace Northwind.Tests.Core.Infrastructure.Persistance.Mappings
{
    public class ProductMapTests : AbstractIntegrationTestBase
    {
        [Fact]
        public void Should_Map_Product()
        {
            var category = new Category { Name = "some category" };
            var supplier = new Supplier { Name = "some supplier" };
            
            using (var session = SessionFactory.OpenSession())
            {
                session.Save(category);
                session.Save(supplier);
            }
            
            using (var session = SessionFactory.OpenSession())
            {
                new PersistenceSpecification<Product>(session)
                   .CheckProperty(x => x.Name, "some name")
                   .CheckReference(x => x.Category, category, c => c.Id == category.Id)
                   .CheckReference(x => x.Supplier, supplier, s => s.Id == supplier.Id)
                   .CheckProperty(x => x.Price, 100.50m)
                   .CheckProperty(x => x.InStock, 100)
                   .CheckProperty(x => x.OnOrder, 50)
                   .CheckProperty(x => x.ReorderLevel, 20)
                   .CheckProperty(x => x.Discontinued, true)
                   .VerifyTheMappings();
            }
        }
    }
}
