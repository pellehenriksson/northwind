namespace Northwind.Write
{
    public interface ICommandInvoker
    {
        void Execute<T>(T command);
    }
}