using System.Web.Mvc;

using Northwind.Core.Read;

namespace Northwind.Web.Controllers
{
    [Authorize(Roles = "Manager")]
    public class EmployeesController : AbstractApplicationController
    {
        private readonly IQueryRepository queryRepository;

        public EmployeesController(IQueryRepository queryRepository)
        {
            this.queryRepository = queryRepository;
        }

        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            var criteria = new EmployeesListQuery.Criteria { CurrentPage = page, ItemsPerPage = 15 };

            var model = this.queryRepository.Load<EmployeesListQuery.Criteria, PagedListResult<EmployeesListQuery.Result>>(criteria);
            
            return this.View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var criteria = new EmployeeDetailsQuery.Criteria { Id = id };
            var model = this.queryRepository.Load<EmployeeDetailsQuery.Criteria, EmployeeDetailsQuery.Result>(criteria);

            if (model == null)
            {
                return this.HttpNotFound(string.Format("No employee with id: '{0}' was found", id));
            }

            return this.View(model);
        }
    }
}