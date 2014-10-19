using System.Collections.Generic;
using System.Web.Mvc;

using Northwind.Core.Read;

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
        public ActionResult Index()
        {
            var criteria = new OrdersListQuery.Criteria { EmployeeId = CurrentUser.Id };
            var model = this.queryRepository.Load<OrdersListQuery.Criteria, IList<OrdersListQuery.Result>>(criteria);
            
            return this.View(model);
        }
    }
}