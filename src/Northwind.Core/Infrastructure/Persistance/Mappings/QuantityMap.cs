using FluentNHibernate.Mapping;

using Northwind.Core.Domain;

namespace Northwind.Core.Infrastructure.Persistance.Mappings
{
    public class QuantityMap : ComponentMap<Quantity>
    {
        public QuantityMap()
        {
            this.Map(x => x.Value).Not.Nullable();
        }
    }
}
