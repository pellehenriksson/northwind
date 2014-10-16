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
   }

    public class NullPhonenumber : Phonenumber
    {
    }
}
