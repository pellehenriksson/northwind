﻿using FluentNHibernate.Testing;

using Northwind.Core.Domain;

using Xunit;

namespace Northwind.Tests.Core.Infrastructure.Persistance.Mappings
{
    public class ShipperMapTests : AbstractIntegrationTest
    {
        [Fact]
        public void Should_Map_Shipper()
        {
            using (var session = SessionFactory.OpenSession())
            {
                new PersistenceSpecification<Shipper>(session)
                   .CheckProperty(x => x.Name, "some name")
                   .CheckProperty(x => x.Phonenumber, this.GetPhonenumberForTest())
                   .VerifyTheMappings();
            }
        }
    }
}
