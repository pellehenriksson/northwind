using System.Globalization;
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
        private readonly IStatelessSession session;
        
        public LoginController(IStatelessSession session)
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
            var cookie = builder.Build(user.Id.ToString(CultureInfo.InvariantCulture), user.Name, new[] { "fake" });

            Response.Cookies.Add(cookie);

            return this.RedirectToAction("Index", "Home");
        }

        public class LoginModel
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }
    }
}