using System;

namespace Northwind.Core.Domain
{
    public class DomainRuleException : Exception
    {
        public DomainRuleException()
        {
        }

        public DomainRuleException(string message) : base(message)
        {
        }
    }
}
