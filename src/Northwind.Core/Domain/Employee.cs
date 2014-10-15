using System;
using System.Collections.Generic;

namespace Northwind.Core.Domain
{
    public class Employee
    {
        public virtual int Id { get; protected internal set; }

        public virtual string Name { get; set; }

        public virtual string Title { get; set; }

        public virtual DateTime Born { get; set; }

        public virtual DateTime Hired { get; set; }

        public virtual Address Address { get; set; }

        public virtual string Notes { get; set; }

        public virtual Employee ReportsTo { get; set; }

        public virtual IList<Territory> Territories { get; set; }
    }
}
