namespace Northwind.Core.Domain
{
    public class Product
    {
        public virtual int Id { get; protected internal set; }

        public virtual string Name { get; set; }

        public virtual Category Category { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual decimal Price { get; set; }

        public virtual int InStock { get; set; }

        public virtual int OnOrder { get; set; }

        public virtual int ReorderLevel { get; set; }

        public virtual bool Discontinued { get; set; }
    }
}
