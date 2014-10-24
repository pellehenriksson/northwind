namespace Northwind.Core.Write.Commands
{
    public class ChangeCategoryCommand
    {
        public ChangeCategoryCommand(int id, string name, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }
    }
}
