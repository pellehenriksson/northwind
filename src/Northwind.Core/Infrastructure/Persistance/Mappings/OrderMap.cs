﻿using FluentNHibernate.Mapping;

namespace Northwind.Core.Infrastructure.Persistance.Mappings
{
    public class OrderMap : ClassMap<Domain.Order>
    {
        public OrderMap()
        {
            this.Table("Orders");

            this.Id(x => x.Id).GeneratedBy.Identity();

            this.Map(x => x.OrderDate).Not.Nullable();

            this.References(x => x.Customer).Not.Nullable();
            this.HasMany(x => x.Orderlines).ForeignKeyCascadeOnDelete().Inverse();
        }
    }
}