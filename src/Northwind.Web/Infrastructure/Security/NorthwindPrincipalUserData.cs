namespace Northwind.Web.Infrastructure.Security
{
    public class NorthwindPrincipalUserData
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string[] Roles { get; set; }
    }
}