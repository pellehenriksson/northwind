using Northwind.Core.Domain;

using Xunit;

namespace Northwind.Tests.Core.Domain
{
    public class OrderTests
    {
        [Fact]
        public void Sandbox()
        {
            var customer = Customer.Create("big customer", "fancy nancy", new NullAddress(), new NullPhonenumber());

            var order = Order.Create(customer);

            var category = Category.Create("boxes", "really cool boxes");
            var supplier = Supplier.Create("some supplier", new NullAddress(), new NullPhonenumber());

            var product = Product.Create("a box", category, supplier, new Money(1000, "SEK"));

            order.AddOrderLine(product, new Quantity(10));
            order.RemoveOrderline(product);

            Assert.Equal(0, order.Orderlines.Count);
        }
    }
}
