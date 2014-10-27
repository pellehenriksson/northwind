namespace Northwind.Write
{
    public interface ICommandHandler<T>
    {
        void Handle(T command);
    }
}