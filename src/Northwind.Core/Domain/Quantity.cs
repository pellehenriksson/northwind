using Northwind.Core.Common;

namespace Northwind.Core.Domain
{
    public class Quantity : IValueObject
    {
        public Quantity(int value)
        {
            if (value < 1)
            {
                throw new DomainRuleException("Value should be one or higher");
            }

            this.Value = value;
        }

        protected Quantity()
        {
        }

        public int Value { get; protected internal set; }
    }
}
