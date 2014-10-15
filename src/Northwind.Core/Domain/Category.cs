namespace Northwind.Core.Domain
{
    public class Category
    {
        protected Category()
        {
        }

        public virtual int Id { get; protected internal set; }

        public virtual string Name { get; protected internal set; }

        public virtual string Description { get; protected internal set; }

        public static Category Create(string name, string description)
        {
            return new Category { Name = name, Description = description };
        }

        public virtual void ChangeName(string name)
        {
            this.Name = name;
        }

        public virtual void ChangeDescription(string description)
        {
            this.Description = description;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((Category)obj);
        }

        public override int GetHashCode()
        {
            return this.Id;
        }

        protected bool Equals(Category other)
        {
            return this.Id == other.Id;
        }
    }
}
