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

            return this.Equals((Address)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = this.Street != null ? this.Street.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (this.PostalCode != null ? this.PostalCode.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.City != null ? this.City.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Region != null ? this.Region.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Country != null ? this.Country.GetHashCode() : 0);
                return hashCode;
            }
        }

        protected bool Equals(Address other)
        {
            return string.Equals(this.Street, other.Street) && string.Equals(this.PostalCode, other.PostalCode) && string.Equals(this.City, other.City) && string.Equals(this.Region, other.Region) && string.Equals(this.Country, other.Country);
        }
    }

    public class NullAddress : Address
    {
    }
}
