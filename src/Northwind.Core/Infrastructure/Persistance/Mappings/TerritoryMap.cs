using FluentNHibernate.Mapping;

using Northwind.Core.Domain;

namespace Northwind.Core.Infrastructure.Persistance.Mappings
{
    public class TerritoryMap : ClassMap<Territory>
    {
        public TerritoryMap()
        {
            this.Table("Territories");

            this.Id(x => x.Id).GeneratedBy.Identity();
            this.Map(x => x.Name).Length(15).Not.Nullable();
            
            this.References(x => x.Region).Not.Nullable()
                .Index("ix_territory_region")
                .ForeignKey("fk_region");
        }
    }
}
