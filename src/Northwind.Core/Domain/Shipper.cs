namespace Northwind.Core.Domain
{
    public class Shipper
    {
        public virtual int Id { get; protected internal set; }

        public virtual string Name { get; set; }

        public virtual Phonenumber Phonenumber { get; set; }
    }
}
