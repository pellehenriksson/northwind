using Northwind.Core.Common;

namespace Northwind.Core.Domain
{
    public class Money : IValueObject
    {
        public Money(decimal amount, string currency)
        {
            this.Amount = amount;
            this.Currency = currency;
        }

        protected Money()
        {
        }

        public decimal Amount { get; protected internal set; }

        public string Currency { get; protected internal set; }
        
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

            return this.Equals((Money)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (this.Amount.GetHashCode() * 397) ^ (this.Currency != null ? this.Currency.GetHashCode() : 0);
            }
        }

        protected bool Equals(Money other)
        {
            return this.Amount == other.Amount && string.Equals(this.Currency, other.Currency);
        }
    }
}
