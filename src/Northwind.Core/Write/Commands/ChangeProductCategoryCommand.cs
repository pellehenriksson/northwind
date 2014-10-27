namespace Northwind.Core.Write.Commands
{
    public class ChangeProductCategoryCommand
    {
        public ChangeProductCategoryCommand(int id, int categoryId)
        {
            this.Id = id;
            this.CategoryId = categoryId;
        }

        public int Id { get; private set; }

        public int CategoryId { get; private set; }
    }
}
