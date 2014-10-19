namespace Northwind.Web.Infrastructure.Security
{
    public class NorthwindPrincipalUserData
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string[] Roles { get; set; }
    }
}