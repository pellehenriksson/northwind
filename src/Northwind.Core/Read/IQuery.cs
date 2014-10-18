namespace Northwind.Core.Read
{
    public interface IQuery<TInput, TOutput>
    {
        TOutput Load(TInput model);
    }
}
