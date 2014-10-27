using System.Web.Mvc;

using Northwind.Read;

namespace Northwind.Web.Controllers
{
    public class OrdersController : AbstractApplicationController
    {
        private readonly IQueryRepository queryRepository;

        public OrdersController(IQueryRepository queryRepository)
        {
            this.queryRepository = queryRepository;
        }

        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            var criteria = new OrdersListQuery.Criteria { EmployeeId = CurrentUser.Id, CurrentPage = page, ItemsPerPage = 15 };
            var model = this.queryRepository.Load<OrdersListQuery.Criteria, PagedListResult<OrdersListQuery.Result>>(criteria);
            
            return this.View(model);
        }
    }
}