using FluentNHibernate.Mapping;

using Northwind.Core.Domain;

namespace Northwind.Core.Infrastructure.Persistance.Mappings
{
    public class AddressMap : ComponentMap<Address>
    {
        public AddressMap()
        {
            this.Map(x => x.Street);
            this.Map(x => x.PostalCode);
            this.Map(x => x.City);
            this.Map(x => x.Region);
            this.Map(x => x.Country);
        }
    }
}
