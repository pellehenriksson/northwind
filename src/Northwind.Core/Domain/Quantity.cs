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

            return this.Equals((Quantity)obj);
        }
        
        public override int GetHashCode()
        {
            return this.Value;
        }

        protected bool Equals(Quantity other)
        {
            return this.Value == other.Value;
        }
    }
}
