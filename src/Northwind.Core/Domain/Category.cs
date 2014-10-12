namespace Northwind.Core.Domain
{
    public class Category
    {
        public virtual int Id { get; protected internal set; }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }
    }
}
