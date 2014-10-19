using System;

using Northwind.Core.Domain;

using Xunit;

namespace Northwind.Tests.Core.Domain
{
    public class OrderTests
    {
        [Fact]
        public void Sandbox()
        {
            var employee = Employee.Create("Michael Scott", new DateTime(1960, 1, 1), DateTime.Today.AddYears(-10));
            var customer = Customer.Create("big customer", "fancy nancy", new NullAddress(), new NullPhonenumber());

            var order = Order.Create(customer, employee);

            var category = Category.Create("boxes", "really cool boxes");
            var supplier = Supplier.Create("some supplier", new NullAddress(), new NullPhonenumber());

            var product = Product.Create("a box", category, supplier, new Money(1000, "SEK"));

            order.AddOrderLine(product, new Quantity(10));
            order.RemoveOrderline(product);

            Assert.Equal(0, order.Orderlines.Count);
        }
    }
}
