namespace Northwind.Web.ViewModels
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int InStock { get; set; }

        public int ReorderLevel { get; set; }

        public bool Discontinued { get; set; }

        public string Category { get; set; }
        
        public decimal Price { get; set; }

        public string Currency { get; set; }
    }
}