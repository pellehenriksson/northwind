namespace Northwind.Core.Domain
{
    public class Supplier
    {
        protected Supplier()
        {
        }

        public virtual int Id { get; protected internal set; }

        public virtual string Name { get; protected internal set; }

        public virtual Address Address { get; protected internal set; }

        public virtual Phonenumber Phonenumber { get; protected internal set; }

        public static Supplier Create(string name, Address address, Phonenumber phonenumber)
        {
            return new Supplier { Name = name, Address = address, Phonenumber = phonenumber };
        }

        public virtual void ChangeName(string name)
        {
            this.Name = name;
        }

        public virtual void ChangeAddress(Address address)
        {
            this.Address = address;
        }

        public virtual void ChangePhonenumber(Phonenumber phonenumber)
        {
            this.Phonenumber = phonenumber;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((Supplier)obj);
        }

        public override int GetHashCode()
        {
            return this.Id;
        }

        protected bool Equals(Supplier other)
        {
            return this.Id == other.Id;
        }
    }
}
