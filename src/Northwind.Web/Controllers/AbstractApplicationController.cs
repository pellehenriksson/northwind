using System.Web.Mvc;

using Northwind.Web.Infrastructure.Security;

namespace Northwind.Web.Controllers
{
    [Authorize]
    public class AbstractApplicationController : Controller
    {
        public NorthwindPrincipal CurrentUser
        {
            get { return (NorthwindPrincipal)this.User; }
        }
    }
}