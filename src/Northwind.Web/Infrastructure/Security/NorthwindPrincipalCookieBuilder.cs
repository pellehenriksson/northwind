using System;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Northwind.Web.Infrastructure.Security
{
    public class NorthwindPrincipalCookieBuilder
    {
        public HttpCookie Build(string id, string name, string[] roles)
        {
            var data = new NorthwindPrincipalUserData { Id = id, Name = name, Roles = roles };
            var serializer = new JavaScriptSerializer();
            var serializedData = serializer.Serialize(data);

            var ticket = new FormsAuthenticationTicket(1, name, DateTime.Now, DateTime.Now.AddMinutes(20), false, serializedData);
            var encryptedTicket = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

            return cookie;
        }
    }
}