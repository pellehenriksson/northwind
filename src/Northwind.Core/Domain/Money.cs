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

        public override string ToString()
        {
            return string.Format("{0} {1}", this.Amount, this.Currency);
        }
    }
}
