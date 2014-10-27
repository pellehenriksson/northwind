using System;
using System.Collections.Generic;
using System.Linq;

namespace Northwind.Read
{
    public class PagedListResult<TResult> : IPagedListResult
    {
        private int currentPage;

        public IEnumerable<TResult> Items { get; set; }

        public int TotalNumberOfItems { get; set; }

        public int ItemsPerPage { get; set; }

        public int NumberOfItemsOnCurrentPage
        {
            get { return this.Items == null ? 0 : this.Items.Count(); }
        }

        public int CurrentPage
        {
            get
            {
                return this.currentPage;
            }

            set
            {
                if (value < 1)
                {
                    this.currentPage = 1;
                }

                this.currentPage = value;
            }
        }

        public int TotalNumberOfPages
        {
            get { return (int)Math.Ceiling((decimal)this.TotalNumberOfItems / this.ItemsPerPage); }
        }
    }
}
