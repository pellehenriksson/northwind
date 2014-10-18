namespace Northwind.Core.Read
{
    public interface IQueryRepository
    {
        TOutput Load<TInput, TOutput>(TInput input);
    }
}
