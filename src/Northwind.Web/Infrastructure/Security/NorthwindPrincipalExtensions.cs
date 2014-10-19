using System.Security.Principal;

namespace Northwind.Web.Infrastructure.Security
{
    public static class NorthwindPrincipalExtensions
    {
        public static string GetDisplayName(this IPrincipal principal)
        {
            return ((NorthwindPrincipal)principal).Name;
        }
   }
}