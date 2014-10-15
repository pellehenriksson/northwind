namespace Northwind.Core.Domain
{
    public class Supplier
    {
        public virtual int Id { get; protected internal set; }

        public virtual string Name { get; set; }

        public virtual Address Address { get; set; }

        public virtual Phonenumber Phonenumber { get; set; }
    }
}
