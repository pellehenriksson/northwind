using System.Collections.Generic;
using System.Web.Mvc;

using NLog.Interface;

using Northwind.Core.Read;
using Northwind.Core.Write;

namespace Northwind.Web.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly IQueryRepository queryRepository;

        private ICommandInvoker commandInvoker;

        private ILogger logger;

        public EmployeesController(IQueryRepository queryRepository, ICommandInvoker commandInvoker, ILogger logger)
        {
            this.queryRepository = queryRepository;
            this.commandInvoker = commandInvoker;
            this.logger = logger;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = this.queryRepository.Load<EmployeesListQuery.Criteria, IList<EmployeesListQuery.Result>>(new EmployeesListQuery.Criteria());
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