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
            var category = Category.Create("name", "description");
            var supplier = Supplier.Create("suppliername", this.GetAddressForTest(), this.GetPhonenumberForTest());
            
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
                   .CheckProperty(x => x.Price, new Money(1000, "SEK"))
                   .CheckProperty(x => x.InStock, 100)
                   .CheckProperty(x => x.ReorderLevel, 20)
                   .CheckProperty(x => x.Discontinued, true)
                   .VerifyTheMappings();
            }
        }
    }
}
