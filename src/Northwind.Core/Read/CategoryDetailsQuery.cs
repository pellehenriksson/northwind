using NHibernate;

using Northwind.Core.Domain;

namespace Northwind.Core.Read
{
    public class CategoryDetailsQuery : IQuery<CategoryDetailsQuery.Criteria, CategoryDetailsQuery.Result>
    {
        private readonly IStatelessSession session;

        public CategoryDetailsQuery(IStatelessSession session)
        {
            this.session = session;
        }

        public Result Load(Criteria criteria)
        {
            var category = this.session.Get<Category>(criteria.CategoryId);
            if (category == null)
            {
                return null;
            }
            
            return new Result
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
            };
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
