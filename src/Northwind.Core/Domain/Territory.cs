namespace Northwind.Core.Domain
{
    public class Territory
    {
        public virtual int Id { get; protected internal set; }

        public virtual string Name { get; set; }

        public virtual Region Region { get; set; }
    }
}
