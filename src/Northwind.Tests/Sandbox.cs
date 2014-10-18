using System;
using System.Collections.Generic;
using System.Linq;

using NHibernate;
using NHibernate.Linq;
using Northwind.Core.Domain;
using Northwind.Core.Read;

using Xunit;

namespace Northwind.Tests
{
    public class Sandbox : AbstractIntegrationTestsWithDataBase
    {
        [Fact]
        public void Try_out_a_query()
        {
            using (var session = SessionFactory.OpenStatelessSession())
            {
                var q = new ProductsQuery(session);
                var r = q.Load(new ProductsQuery.Criteria { Name = "a" });

                Console.Out.WriteLine(r.Count);
            }
        }
        
        public class ProductsQuery : IQuery<ProductsQuery.Criteria, IList<ProductsQuery.Result>>
        {
            private readonly IStatelessSession session;

            public ProductsQuery(IStatelessSession session)
            {
                this.session = session;
            }

            public class Criteria
            {
                public string Name { get; set; }
            }

            public class Result
            {
                public int Id { get; set; }

                public string Name { get; set; }
            }

            public IList<Result> Load(Criteria model)
            {
                var query =
                    this.session.Query<Product>()
                        .Where(x => x.Name.StartsWith(model.Name))
                        .OrderBy(x => x.Name)
                        .Select(x => new Result { Id = x.Id, Name = x.Name });

                return query.ToList();
            }
        }
    }
}
