using FluentNHibernate.Mapping;

using Northwind.Core.Domain;

namespace Northwind.Core.Infrastructure.Persistance.Mappings
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            this.Table("Customers");

            this.Id(x => x.Id).GeneratedBy.Identity();

            this.Map(x => x.Name).Not.Nullable().Length(40);
            this.Map(x => x.Contact).Not.Nullable().Length(40);
            
            this.Component(x => x.Address).ColumnPrefix("Address");
            this.Component(x => x.Phonenumber).ColumnPrefix("Phonenumber");
        }
    }
}
