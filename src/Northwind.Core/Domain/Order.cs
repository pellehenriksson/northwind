using System;
using System.Collections.Generic;
using System.Linq;

using Northwind.Core.Common;

namespace Northwind.Core.Domain
{
    public class Order : IAggregateRoot
    {
        protected Order()
        {
        }

        public virtual int Id { get; protected internal set; }

        public virtual DateTime OrderDate { get; protected internal set; }

        public virtual Customer Customer { get; protected internal set; }

        public virtual IList<Orderline> Orderlines { get; protected internal set; }

        public static Order Create(Customer customer)
        {
            if (customer == null)
            {
                throw new DomainRuleException("Customer should not be null");
            }

            var order = new Order { OrderDate = DateTime.UtcNow, Customer = customer, Orderlines = new List<Orderline>() };
            return order;
        }

        public virtual void AddOrderLine(Product product, Quantity quantity)
        {
            if (product == null)
            {
                throw new DomainRuleException("Product should not be null");
            }

            if (quantity == null)
            {
                throw new DomainRuleException("Quantity should not be null");
            }

            var orderline = this.Orderlines.FirstOrDefault(x => x.Product == product);

            if (orderline != null)
            {
                orderline.ChangeQuantity(quantity);
            }
            else
            {
                orderline = Orderline.Create(product, quantity);
                this.Orderlines.Add(orderline);
            }
        }

        public virtual void RemoveOrderline(Product product)
        {
            var orderline = this.Orderlines.FirstOrDefault(x => x.Product == product);
            if (orderline != null)
            {
                this.Orderlines.Remove(orderline);
            }
        }
    }
}
