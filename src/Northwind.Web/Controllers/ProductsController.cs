using System.Globalization;
using System.Linq;
using System.Web.Mvc;

using NHibernate;
using NHibernate.Linq;

using Northwind.Core.Domain;
using Northwind.Core.Read;
using Northwind.Core.Write;
using Northwind.Core.Write.Commands;
using Northwind.Web.InputModels;
using Northwind.Web.ViewModels;

namespace Northwind.Web.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ProductsController : AbstractApplicationController
    {
        private readonly IQueryRepository queryRepository;

        private readonly IStatelessSession session;

        private readonly ICommandInvoker commandInvoker;

        public ProductsController(IQueryRepository queryRepository, IStatelessSession session, ICommandInvoker commandInvoker)
        {
            this.queryRepository = queryRepository;
            this.session = session;
            this.commandInvoker = commandInvoker;
        }

        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            var criteria = new PagedCriteria { CurrentPage = page, ItemsPerPage = 15 };
            var model = this.queryRepository.Load<PagedCriteria, PagedListResult<ProductsListQuery.Result>>(criteria);

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var product =
                this.session.Query<Product>()
                    .Where(x => x.Id == id)
                    .Fetch(x => x.Category)
                    .SingleOrDefault();

            if (product == null)
            {
                return this.HttpNotFound(string.Format("No product with id: '{0}' was found", id));
            }

            var model = new ProductDetailsViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Discontinued = product.Discontinued,
                Category = product.Category.Name,
                InStock = product.InStock,
                ReorderLevel = product.ReorderLevel,
                Price = product.Price.Amount,
                Currency = product.Price.Currency
            };

            return this.View(model);
        }

        [HttpGet]
        public ActionResult ChangeName(int id)
        {
            var product = this.session.Get<Product>(id);
            
            if (product == null)
            {
                return this.HttpNotFound(string.Format("No product with id: '{0}' was found", id));
            }

            var model = new ProductNameInputModel { Id = product.Id, Name = product.Name };
            return this.View(model);
        }

        [HttpPost]
        public ActionResult ChangeName(ProductNameInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                var command = new ChangeProductNameCommand(model.Id, model.Name);
                this.commandInvoker.Execute(command);

                this.DisplaySuccessMessage("Name was changed");
                return this.RedirectToAction("Details", new { Id = model.Id });
            }
            catch (DomainRuleException dex)
            {
                this.ModelState.AddModelError(string.Empty, dex.Message);
                return this.View(model);
            }
        }

        [HttpGet]
        public ActionResult ChangeCategory(int id)
        {
            var product = this.session.Get<Product>(id);

            if (product == null)
            {
                return this.HttpNotFound(string.Format("No product with id: '{0}' was found", id));
            }

            this.LoadCategoriesList();
            var model = new ProductCategoryInputModel { Id = product.Id, CategoryId = product.Category.Id };

            return this.View(model);
        }

        [HttpPost]
        public ActionResult ChangeCategory(ProductCategoryInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                this.LoadCategoriesList();
                return this.View(model);
            }

            try
            {
                var command = new ChangeProductCategoryCommand(model.Id, model.CategoryId);
                this.commandInvoker.Execute(command);

                this.DisplaySuccessMessage("Category was changed");
                return this.RedirectToAction("Details", new { Id = model.Id });
            }
            catch (DomainRuleException dex)
            {
                this.ModelState.AddModelError(string.Empty, dex.Message);
                this.LoadCategoriesList();
                return this.View(model);
            }
        }

        private void LoadCategoriesList()
        {
            var list =
                this.session.Query<Category>()
                    .OrderBy(x => x.Name)
                    .Select(x => new SelectListItem { Value = x.Id.ToString(CultureInfo.InvariantCulture), Text = x.Name })
                    .ToList();

            this.ViewBag.Categories = list;
        }
    }
}