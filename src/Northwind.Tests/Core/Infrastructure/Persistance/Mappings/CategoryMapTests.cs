﻿using FluentNHibernate.Testing;

using Northwind.Core.Domain;

using Xunit;

namespace Northwind.Tests.Core.Infrastructure.Persistance.Mappings
{
    public class CategoryMapTests : AbstractIntegrationTestBase
    {
        [Fact]
        public void Should_Map_Category()
        {
            using (var session = SessionFactory.OpenSession())
            {
                new PersistenceSpecification<Category>(session)
                   .CheckProperty(x => x.Name, "some name")
                   .CheckProperty(x => x.Description, "some description")
                   .VerifyTheMappings();
            }
        }
    }
}