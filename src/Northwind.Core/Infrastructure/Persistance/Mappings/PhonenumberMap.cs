using FluentNHibernate.Mapping;

using Northwind.Core.Domain;

namespace Northwind.Core.Infrastructure.Persistance.Mappings
{
    public class PhonenumberMap : ComponentMap<Phonenumber>
    {
        public PhonenumberMap()
        {
            this.Map(x => x.Number).Length(50).Nullable();
            this.Map(x => x.Description).Length(200).Nullable();
        }
    }
}
