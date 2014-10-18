namespace Northwind.Core.Write
{
    public interface ICommandInvoker
    {
        void Execute<T>(T command);
    }
}