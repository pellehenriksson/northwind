namespace Northwind.Core.Domain
{
    public class Territory
    {
        protected Territory()
        {
        }

        public virtual int Id { get; protected internal set; }

        public virtual string Name { get; protected internal set; }

        public virtual Region Region { get; protected internal set; }

        public static Territory Create(string name, Region region)
        {
            return new Territory { Name = name, Region = region };
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

            return this.Equals((Territory)obj);
        }
        
        public override int GetHashCode()
        {
            return this.Id;
        }

        protected bool Equals(Territory other)
        {
            return this.Id == other.Id;
        }
    }
}
