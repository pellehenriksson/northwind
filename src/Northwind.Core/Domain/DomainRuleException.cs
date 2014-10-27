using System;
using System.Runtime.Serialization;

namespace Northwind.Core.Domain
{
    [Serializable]
    public class DomainRuleException : Exception
    {
        public DomainRuleException(string message) : base(message)
        {
        }

        protected DomainRuleException(SerializationInfo info, StreamingContext ctxt) : base(info, ctxt)
        {
            
        }
    }
}

