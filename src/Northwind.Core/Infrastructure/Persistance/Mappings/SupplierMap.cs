using FluentNHibernate.Mapping;

using Northwind.Core.Domain;

namespace Northwind.Core.Infrastructure.Persistance.Mappings
{
    public class SupplierMap : ClassMap<Supplier>
    {
        public SupplierMap()
        {
            this.Table("Suppliers");

            this.Id(x => x.Id).GeneratedBy.Identity();
            this.Map(x => x.Name).Length(50).Not.Nullable();
        }
    }
}
