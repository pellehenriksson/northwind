using Northwind.Core.Common;

namespace Northwind.Core.Domain
{
    public class Customer : IAggregateRoot
    {
        protected Customer()
        {
        }

        public virtual int Id { get; protected internal set; }

        //// This is the id from the old system
        public virtual string TraceId { get; protected internal set; }

        public virtual string Name { get; protected internal set; }

        public virtual string Contact { get; protected internal set; }

        public virtual Address Address { get; protected internal set; }

        public virtual Phonenumber Phonenumber { get; protected internal set; }

        public static Customer Create(string name, string contact, Address address, Phonenumber phonenumber)
        {
            var customer = new Customer();

            customer.ChangeName(name);
            customer.ChangeContact(contact);
            customer.ChangeAddress(address);
            customer.ChangePhonennumber(phonenumber);

            return customer;
        }

        public virtual void ChangeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainRuleException("Name should not be empty");
            }

            this.Name = name;
        }

        public virtual void ChangeContact(string contact)
        {
            this.Contact = contact;
        }

        public virtual void ChangeAddress(Address address)
        {
            if (address == null)
            {
                throw new DomainRuleException("Address should not be null");
            }
            
            this.Address = address;
        }

        public virtual void ChangePhonennumber(Phonenumber phonenumber)
        {
            if (phonenumber == null)
            {
                throw new DomainRuleException("Phonenumber should not be null");
            }

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

            return this.Equals((Customer)obj);
        }

        public override int GetHashCode()
        {
            return this.Id;
        }

        protected bool Equals(Customer other)
        {
            return this.Id == other.Id;
        }
    }
}
