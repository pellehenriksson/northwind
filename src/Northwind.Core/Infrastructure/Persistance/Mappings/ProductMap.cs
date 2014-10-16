using FluentNHibernate.Mapping;

using Northwind.Core.Domain;

namespace Northwind.Core.Infrastructure.Persistance.Mappings
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            this.Table("Products");

            this.Id(x => x.Id).GeneratedBy.Identity();

            this.Map(x => x.Name).Length(40).Not.Nullable();
            
            this.References(x => x.Category).Not.Nullable()
                    .Index("ix_product_category")
                    .ForeignKey("fk_product_category");
            
            this.References(x => x.Supplier).Not.Nullable()
                    .Index("ix_product_supplier")
                    .ForeignKey("fk_product_supplier");
            
            this.Map(x => x.InStock).Not.Nullable();
            this.Map(x => x.ReorderLevel).Not.Nullable();
            this.Map(x => x.Discontinued).Not.Nullable();

            this.Component(x => x.Price).ColumnPrefix("Price");
        }
    }
}
