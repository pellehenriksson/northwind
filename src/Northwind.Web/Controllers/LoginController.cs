using System.Linq;
using System.Web.Mvc;

using NHibernate;
using NHibernate.Linq;

using Northwind.Core.Domain;
using Northwind.Web.Infrastructure.Security;

namespace Northwind.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISession session;

        public LoginController(ISession session)
        {
            this.session = session;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model =
                this.session.Query<Employee>()
                    .OrderBy(x => x.Name)
                    .Select(x => new LoginModel { Id = x.Id, Name = x.Name + " (" + x.Title + ")" })
                    .ToList();

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Index(int id)
        {
            var user = this.session.Get<Employee>(id);
            
            if (user == null)
            {
                this.ModelState.AddModelError("Login", "Login failed");
                return this.RedirectToAction("Index");
            }

            var builder = new NorthwindPrincipalCookieBuilder();
            var cookie = builder.Build(user.Id, user.Name, new[] { this.ResolveRole(user) });

            Response.Cookies.Add(cookie);

            //if (!string.IsNullOrWhiteSpace(returnUrl))
            //{
            //    return this.Redirect(returnUrl);
            //}

            return this.RedirectToAction("Index", "Home");
        }

        private string ResolveRole(Employee user)
        {
            return user.ReportsTo != null ? NorthwindUserRoles.User : NorthwindUserRoles.Manager;
        }

        public class LoginModel
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }
    }
}