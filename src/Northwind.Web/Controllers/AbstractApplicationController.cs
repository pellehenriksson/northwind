using System;
using System.Web.Mvc;

using Northwind.Web.Infrastructure;
using Northwind.Web.Infrastructure.Security;

namespace Northwind.Web.Controllers
{
    [Authorize]
    public class AbstractApplicationController : Controller
    {
        protected NorthwindPrincipal CurrentUser
        {
            get { return (NorthwindPrincipal)this.User; }
        }

        protected void DisplaySuccessMessage(string message)
        {
            this.TempData[SystemMessage.Key] = SystemMessage.CreateSuccessMessage("Success", message);
        }

        protected void DisplayErrorMessage(Exception ex)
        {
            this.TempData[SystemMessage.Key] = SystemMessage.CreateErrorMessage("Error", ex.Message);
        }

        protected void DisplayErrorMessage(string message)
        {
            this.TempData[SystemMessage.Key] = SystemMessage.CreateErrorMessage("Error", message);
        }
    }
}