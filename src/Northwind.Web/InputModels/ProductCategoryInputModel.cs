using System.ComponentModel;

namespace Northwind.Web.InputModels
{
    public class ProductCategoryInputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }
    }
}