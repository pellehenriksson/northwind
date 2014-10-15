namespace Northwind.Core.Domain
{
    public class Shipper
    {
        protected Shipper()
        {
        }

        public virtual int Id { get; protected internal set; }

        public virtual string Name { get; protected internal set; }
        
        public virtual Phonenumber Phonenumber { get; protected internal set; }

        public static Shipper Create(string name, Phonenumber phonenumber)
        {
            return new Shipper { Name = name, Phonenumber = phonenumber };
        }

        public virtual void ChangeName(string name)
        {
            this.Name = name;
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

            return this.Equals((Shipper)obj);
        }
        
        public override int GetHashCode()
        {
            return this.Id;
        }

        protected bool Equals(Shipper other)
        {
            return this.Id == other.Id;
        }
    }
}
