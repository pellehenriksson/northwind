using System;

using Northwind.Core.Domain;

using Xunit;

namespace Northwind.Tests.Core.Infrastructure.Persistance.Mappings
{
    public class OrderMapTests : AbstractIntegrationTestBase
    {
        [Fact]
        public void Should_map_Order()
        {
            using (var session = SessionFactory.OpenSession())
            {
                var employee = Employee.Create("Michael Scott", new DateTime(1960, 1, 1), DateTime.Today.AddYears(-10));
                var customer = Customer.Create("big customer", "fancy nancy", this.GetAddressForTest(), this.GetPhonenumberForTest());
                var category = Category.Create("boxes", "really cool boxes");
                var supplier = Supplier.Create("some supplier", this.GetAddressForTest(), this.GetPhonenumberForTest());
                var product = Product.Create("a box", category, supplier, new Money(1000, "SEK"));

                session.Save(employee);
                session.Save(customer);
                session.Save(category);
                session.Save(supplier);
                session.Save(product);
                
                var order = Order.Create(customer, employee);
                order.AddOrderLine(product, new Quantity(10));

                session.Save(order);
            }
        }
    }
}
