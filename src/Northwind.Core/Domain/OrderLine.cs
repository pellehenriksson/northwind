namespace Northwind.Core.Domain
{
    public class Orderline
    {
        protected Orderline()
        {
        }

        public virtual int Id { get; protected internal set; }

        public virtual Product Product { get; protected internal set; }

        public virtual Money UnitPrice { get; protected internal set; }

        public virtual Quantity Quantity { get; protected internal set; }

        public static Orderline Create(Product product, Quantity quantity)
        {
            var orderline = new Orderline { Product = product, UnitPrice = product.Price };
            orderline.ChangeQuantity(quantity);
            return orderline;
        }

        public virtual void ChangeQuantity(Quantity quantity)
        {
            if (quantity == null)
            {
                throw new DomainRuleException("Quantity should not be null");
            }

            this.Quantity = quantity;
        }
    }
}
