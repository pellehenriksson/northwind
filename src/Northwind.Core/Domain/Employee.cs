using System;
using System.Collections.Generic;

using Northwind.Core.Common;

namespace Northwind.Core.Domain
{
    public class Employee : IAggregateRoot
    {
        protected Employee()
        {
        }

        public virtual int Id { get; protected internal set; }

        public virtual string Name { get; protected internal set; }

        public virtual string Title { get; protected internal set; }

        public virtual DateTime DayOfBirth { get; protected internal set; }

        public virtual DateTime HiredDate { get; protected internal set; }

        public virtual Address Address { get; protected internal set; }

        public virtual string Notes { get; protected internal set; } // ? naming

        public virtual Employee ReportsTo { get; protected internal set; }

        public virtual IList<Territory> Territories { get; protected internal set; }

        public static Employee Create(string name)
        {
            return new Employee { Name = name };
        }

        public virtual void ChangeName(string name)
        {
            this.Name = name;
        }

        public virtual void ChangeTitle(string title)
        {
            this.Title = title;
        }

        public virtual void ChangeDayOfBirth(DateTime dayOfBirth)
        {
            this.DayOfBirth = dayOfBirth;
        }

        public virtual void ChangeHiredDate(DateTime hiredDate)
        {
            this.HiredDate = hiredDate;
        }

        public virtual void ChangeAddress(Address address)
        {
            this.Address = address;
        }

        public virtual void ChangeReportsTo(Employee employee)
        {
            // can't reports to self or null

            this.ReportsTo = employee;
        }

        public virtual void AddTerritory(Territory territory)
        {
            // check if already exists

            this.Territories.Add(territory);
        }

        public virtual void RemoveTerritory(Territory territory)
        {
            // implement
        }

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

            return this.Equals((Employee)obj);
        }
        
        public override int GetHashCode()
        {
            return this.Id;
        }

        protected bool Equals(Employee other)
        {
            return this.Id == other.Id;
        }
    }
}
