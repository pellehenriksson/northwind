using FluentNHibernate.Mapping;

using Northwind.Core.Domain;

namespace Northwind.Core.Infrastructure.Persistance.Mappings
{
    public class ShipperMap : ClassMap<Shipper>
    {
        public ShipperMap()
        {
            this.Table("Shippers");

            this.Id(x => x.Id).GeneratedBy.Identity();
            this.Map(x => x.Name).Length(40).Not.Nullable();
           
            this.Component(x => x.Phonenumber).ColumnPrefix("Phonenumber");
        }
    }
}
