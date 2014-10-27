namespace Northwind.Write.Commands
{
    public class CreateCategoryCommand
    {
        public CreateCategoryCommand(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }
    }
}
