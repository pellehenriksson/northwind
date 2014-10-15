namespace Northwind.Core.Domain
{
    public class Region
    {
        protected Region()
        {
        }

        public virtual int Id { get; protected internal set; }

        public virtual string Name { get; protected internal set; }
        
        public static Region Create(string name)
        {
            return new Region { Name = name };
        }

        public virtual void ChangeName(string name)
        {
            this.Name = name;
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

            return this.Equals((Region)obj);
        }

        public override int GetHashCode()
        {
            return this.Id;
        }

        protected bool Equals(Region other)
        {
            return this.Id == other.Id;
        }
    }
}
