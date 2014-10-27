using System.Linq;

using NHibernate;
using NHibernate.Linq;

using Northwind.Core.Domain;

namespace Northwind.Read
{
    public class CategoryDetailsQuery : IQuery<CategoryDetailsQuery.Criteria, CategoryDetailsQuery.Result>
    {
        private readonly ISession session;

        public CategoryDetailsQuery(ISession session)
        {
            this.session = session;
        }

        public Result Load(Criteria criteria)
        {
            var category =
                this.session.Query<Category>()
                    .Where(x => x.Id == criteria.CategoryId)
                    .Select(x => new Result { Id = x.Id, Name = x.Name, Description = x.Description })
                    .SingleOrDefault();

            return category;
        }
        
        public class Criteria
        {
            public int CategoryId { get; set; }
        }

        public class Result
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Description { get; set; }
        }
    }
}
