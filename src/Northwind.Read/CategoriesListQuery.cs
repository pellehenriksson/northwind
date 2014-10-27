using System.Linq;

using NHibernate;
using NHibernate.Linq;

using Northwind.Core.Domain;

namespace Northwind.Read
{
    public class CategoriesListQuery : IQuery<PagedCriteria, PagedListResult<CategoriesListQuery.Result>>
    {
        private readonly ISession session;

        public CategoriesListQuery(ISession session)
        {
            this.session = session;
        }

        public PagedListResult<Result> Load(PagedCriteria criteria)
        {
            var count = this.session.Query<Category>().Count();

            var result = new PagedListResult<Result>
            {
                TotalNumberOfItems = count,
                CurrentPage = criteria.CurrentPage,
                ItemsPerPage = criteria.ItemsPerPage
            };

            var items =
                this.session.Query<Category>()
                    .OrderBy(x => x.Name)
                    .Select(x => new Result { Id = x.Id, Name = x.Name, Description = x.Description })
                    .Skip((result.CurrentPage - 1) * result.ItemsPerPage)
                    .Take(result.ItemsPerPage)
                    .ToList();

            result.Items = items;

            return result;
        }

        public class Result
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Description { get; set; }
        }
    }
}
