using System;
using System.Globalization;
using System.Security.Principal;

namespace Northwind.Web.Infrastructure.Security
{
    public class NorthwindPrincipal : GenericPrincipal
    {
        public NorthwindPrincipal(string id, NorthwindPrincipalUserData data) : base(new GenericIdentity(id.ToString(CultureInfo.InvariantCulture)), data.Roles)
        {
            this.Id = data.Id;
            this.Name = data.Name;
            this.Roles = data.Roles;
        }

        public NorthwindPrincipal(IIdentity identity, string[] roles) : base(identity, roles)
        {
            throw new InvalidOperationException("Call constructor overload");
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string[] Roles { get; set; }

        public string DisplayName
        {
            get { return string.Format("{0} ({1})", this.Name, this.Roles[0]); }
        }
    }
}