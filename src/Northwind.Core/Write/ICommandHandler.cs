namespace Northwind.Core.Write
{
    public interface ICommandHandler<T>
    {
        void Handle(T command);
    }
}