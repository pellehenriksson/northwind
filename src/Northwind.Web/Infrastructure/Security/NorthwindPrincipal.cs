using System;
using System.Security.Principal;

namespace Northwind.Web.Infrastructure.Security
{
    public class NorthwindPrincipal : GenericPrincipal
    {
        public NorthwindPrincipal(string id, NorthwindPrincipalUserData data)
            : base(new GenericIdentity(id), data.Roles)
        {
            this.Id = data.Id;
            this.Name = data.Name;
        }

        public NorthwindPrincipal(IIdentity identity, string[] roles) : base(identity, roles)
        {
            throw new InvalidOperationException("Call constructor overload");
        }

        public string Id { get; private set; }

        public string Name { get; private set; }
    }
}