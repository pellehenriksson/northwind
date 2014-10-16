using Northwind.Core.Common;

namespace Northwind.Core.Domain
{
    public class Address : IValueObject
    {
        public Address(string street, string postalCode, string city, string region, string country)
        {
            this.Street = street;
            this.PostalCode = postalCode;
            this.City = city;
            this.Region = region;
            this.Country = country;
        }

        protected Address()
        {
        }

        public virtual string Street { get; protected internal set; }

        public virtual string PostalCode { get; protected internal set; }

        public virtual string City { get; protected internal set; }

        public virtual string Region { get; protected internal set; }

        public virtual string Country { get; protected internal set; }
    }

    public class NullAddress : Address
    {
    }
}
