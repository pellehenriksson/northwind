using FluentNHibernate.Mapping;

using Northwind.Core.Domain;

namespace Northwind.Core.Infrastructure.Persistance.Mappings
{
    public class OrderlineMap : ClassMap<Orderline>
    {
        public OrderlineMap()
        {
            this.Table("Orderlines");

            this.Id(x => x.Id).GeneratedBy.Identity();
            
            this.References(x => x.Product).Not.Nullable().ForeignKey("fk_orderlines_products");
            this.Component(x => x.UnitPrice).ColumnPrefix("UnitPrice");
            this.Component(x => x.Quantity).ColumnPrefix("Quantity");
        }
    }
}
