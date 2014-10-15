using System;

namespace Northwind.Core.Domain
{
    public class Phonenumber
    {
        public Phonenumber(string description, string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException("Invalid number, must not be empty", number);
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
}
