namespace Northwind.Core.Read
{
    public interface IPagedListResult
    {
        int TotalNumberOfItems { get; }

        int ItemsPerPage { get;  }

        int NumberOfItemsOnCurrentPage { get; }

        int CurrentPage { get; }

        int TotalNumberOfPages { get; }
    }
}