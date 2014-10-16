using FluentNHibernate.Mapping;

using Northwind.Core.Domain;

namespace Northwind.Core.Infrastructure.Persistance.Mappings
{
    public class MoneyMap : ComponentMap<Money>
    {
        public MoneyMap()
        {
            this.Map(x => x.Amount).Not.Nullable();
            this.Map(x => x.Currency).Not.Nullable();
        }
    }
}
