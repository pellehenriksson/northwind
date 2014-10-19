using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Northwind.Web.Infrastructure.Security
{
    public class NorthwindPrincipalCookieExtractor
    {
        public NorthwindPrincipal Extract(HttpCookie cookie)
        {
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            var serializer = new JavaScriptSerializer();
            var data = serializer.Deserialize<NorthwindPrincipalUserData>(ticket.UserData);

            var principal = new NorthwindPrincipal(ticket.Name, data);
            return principal;
        }
    }
}