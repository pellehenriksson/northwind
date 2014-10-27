using System.Web.Mvc;

using Northwind.Core.Domain;
using Northwind.Core.Write;
using Northwind.Core.Write.Commands;
using Northwind.Read;
using Northwind.Web.InputModels;

namespace Northwind.Web.Controllers
{
    [Authorize(Roles = "Manager")]
    public class CategoriesController : AbstractApplicationController
    {
        private readonly IQueryRepository queryRepository;

        private readonly ICommandInvoker commandInvoker;

        public CategoriesController(IQueryRepository queryRepository, ICommandInvoker commandInvoker)
        {
            this.queryRepository = queryRepository;
            this.commandInvoker = commandInvoker;
        }

        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            var criteria = new PagedCriteria { CurrentPage = page, ItemsPerPage = 15 };
            var model = this.queryRepository.Load<PagedCriteria, PagedListResult<CategoriesListQuery.Result>>(criteria);

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View(new CategoryInputModel());
        }

        [HttpPost]
        public ActionResult Create(CategoryInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                var command = new CreateCategoryCommand(model.Name, model.Description);
                this.commandInvoker.Execute(command);

                this.DisplaySuccessMessage(string.Format("Category: '{0}' was created", model.Name));

                return this.RedirectToAction("Index");
            }
            catch (DomainRuleException dex)
            {
                this.ModelState.AddModelError(string.Empty, dex.Message);
                return this.View(model);
            }
        }

        [HttpGet]
        public ActionResult Change(int id)
        {
            var criteria = new CategoryDetailsQuery.Criteria { CategoryId = id };
            var result = this.queryRepository.Load<CategoryDetailsQuery.Criteria, CategoryDetailsQuery.Result>(criteria);

            if (result == null)
            {
                return this.HttpNotFound(string.Format("No category with id: '{0}' was found", id));
            }

            var model = new CategoryInputModel { Id = result.Id, Name = result.Name, Description = result.Description };

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Change(CategoryInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                var command = new ChangeCategoryCommand(model.Id, model.Name, model.Description);
                this.commandInvoker.Execute(command);

                this.DisplaySuccessMessage(string.Format("Category: '{0}' was changed", model.Name));
                
                return this.RedirectToAction("Index");
            }
            catch (DomainRuleException dex)
            {
                this.ModelState.AddModelError(string.Empty, dex.Message);
                return this.View(model);
            }
        }
    }
}
