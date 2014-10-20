using System.Web.Mvc;

using Northwind.Core.Read;

namespace Northwind.Web.Controllers
{
    public class CategoriesController : AbstractApplicationController
    {
        private readonly IQueryRepository queryRepository;

        public CategoriesController(IQueryRepository queryRepository)
        {
            this.queryRepository = queryRepository;
        }

        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            var criteria = new PagedCriteria { CurrentPage = 1, ItemsPerPage = 15 };
            var model = this.queryRepository.Load<PagedCriteria, PagedListResult<CategoriesListQuery.Result>>(criteria);

            return this.View(model);
        }
    }
}