using FluentNHibernate.Mapping;

using Northwind.Core.Domain;

namespace Northwind.Core.Infrastructure.Persistance.Mappings
{
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            this.Table("Employees");

            this.Id(x => x.Id).GeneratedBy.Identity();

            this.Map(x => x.Name).Not.Nullable();
            this.Map(x => x.Title).Not.Nullable();
            this.Map(x => x.DayOfBirth).Not.Nullable();
            this.Map(x => x.HiredDate).Not.Nullable();
            this.Map(x => x.Notes).CustomSqlType("ntext").Nullable();

            this.References(x => x.ReportsTo)
                .Nullable()
                .Index("ix_employee_employee")
                .ForeignKey("fk_employee_employee");

            this.HasManyToMany(x => x.Territories).Table("EmployeesTerritories");

            this.Component(x => x.Address).ColumnPrefix("Address");
        }
    }
}
