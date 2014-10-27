using System.Linq;

using NHibernate;
using NHibernate.Linq;

using Northwind.Core.Domain;

namespace Northwind.Read
{
    public class ProductsListQuery : IQuery<PagedCriteria, PagedListResult<ProductsListQuery.Result>>
    {
        private readonly ISession session;

        public ProductsListQuery(ISession session)
        {
            this.session = session;
        }

        public PagedListResult<Result> Load(PagedCriteria criteria)
        {
            var count = this.session.Query<Product>().Count();

            var result = new PagedListResult<Result>
            {
                TotalNumberOfItems = count,
                CurrentPage = criteria.CurrentPage,
                ItemsPerPage = criteria.ItemsPerPage
            };

            var items =
                  this.session.Query<Product>()
                      .OrderBy(x => x.Name)
                      .Select(x => new Result
                            {
                                Id = x.Id, 
                                Discontinued = x.Discontinued, 
                                Name = x.Name, 
                                Category = x.Category.Name, 
                                Supplier = x.Supplier.Name,
                                Price = x.Price.Amount, 
                                Currency = x.Price.Currency
                            })
                      .Skip((result.CurrentPage - 1) * result.ItemsPerPage)
                      .Take(result.ItemsPerPage)
                      .ToList();

            result.Items = items;

            return result;
        }

        public class Result
        {
            public int Id { get; set; }

            public bool Discontinued { get; set; }

            public string Name { get; set; }

            public string Category { get; set; }

            public string Supplier { get; set; }

            public decimal Price { get; set; }

            public string Currency { get; set; }
        }
    }
}
