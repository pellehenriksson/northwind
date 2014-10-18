using System.Collections.Generic;
using System.Web.Mvc;

using NLog.Interface;

using Northwind.Core.Read;
using Northwind.Core.Write;

namespace Northwind.Web.Controllers
{
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
    }
}