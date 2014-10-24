using FluentNHibernate.Mapping;

using Northwind.Core.Domain;

namespace Northwind.Core.Infrastructure.Persistance.Mappings
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            this.Table("Categories");

            this.Id(x => x.Id).GeneratedBy.Identity();

            this.Map(x => x.Name).Length(50).Not.Nullable();
            this.Map(x => x.Description).CustomSqlType("ntext").Nullable();
        }
    }
}
