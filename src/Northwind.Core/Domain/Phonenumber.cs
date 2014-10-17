using Northwind.Core.Common;

namespace Northwind.Core.Domain 
{
    public class Phonenumber : IValueObject
    {
        public Phonenumber(string description, string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new DomainRuleException("Number should not be empty");
            }

            this.Description = description;
            this.Number = number;
        }

        protected Phonenumber()
        {
        }

        public virtual string Description { get; protected internal set; }

        public virtual string Number { get; protected internal set; }

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

            return this.Equals((Phonenumber)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((this.Description != null ? this.Description.GetHashCode() : 0) * 397) ^ (this.Number != null ? this.Number.GetHashCode() : 0);
            }
        }

        protected bool Equals(Phonenumber other)
        {
            return string.Equals(this.Description, other.Description) && string.Equals(this.Number, other.Number);
        }
    }

    public class NullPhonenumber : Phonenumber
    {
    }
}
