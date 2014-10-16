namespace Northwind.Core.Domain
{
    public class Product
    {
        protected Product()
        {
        }
        
        public virtual int Id { get; protected internal set; }

        public virtual string Name { get; protected internal set; }

        public virtual Category Category { get; protected internal set; }

        public virtual Supplier Supplier { get; protected internal set; }

        public virtual Money Price { get; protected internal set; }

        public virtual int InStock { get; protected internal set; }

        public virtual int ReorderLevel { get; protected internal set; }

        public virtual bool Discontinued { get; protected internal set; }

        public static Product Create(string name, Category category, Supplier supplier, Money price)
        {
            var product = new Product();
            
            product.ChangeName(name);
            product.ChangeCategory(category);
            product.ChangePrice(price);

            product.Supplier = supplier;

            return product;
        }

        public virtual void ChangeName(string name)
        {
            this.Name = name;
        }

        public virtual void ChangeCategory(Category category)
        {
            this.Category = category;
        }

        public virtual void ChangePrice(Money price)
        {
            this.Price = price;
        }

        public virtual void ChangeReorderLevel(int level)
        {
            this.ReorderLevel = level;
        }

        public virtual void Discontinue()
        {
            this.Discontinued = true;
        }
    }
}
