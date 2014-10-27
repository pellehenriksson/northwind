namespace Northwind.Read
{
    public interface IQuery<TCriteria, TResult>
    {
        TResult Load(TCriteria criteria);
    }
}
