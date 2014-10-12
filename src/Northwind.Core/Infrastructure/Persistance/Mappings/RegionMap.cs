using FluentNHibernate.Mapping;

using Northwind.Core.Domain;

namespace Northwind.Core.Infrastructure.Persistance.Mappings
{
    public class RegionMap : ClassMap<Region>
    {
        public RegionMap()
        {
            this.Table("Regions");

            this.Id(x => x.Id).GeneratedBy.Identity();
            this.Map(x => x.Name).Length(50).Not.Nullable();
        }
    }
}
