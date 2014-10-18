namespace Northwind.Core.Read
{
    public interface IQueryFactory<TInput, TOutput>
    {
        TOutput Load(TInput model);
    }
}
