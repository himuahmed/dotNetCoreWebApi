using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetCoreWebApi.Helpers
{
    public class PaginationHeaders
    {
        public int TotalCount { get; set; }
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }

        public PaginationHeaders(int totalCount, int totalPage, int currentPage, int itemsPerPage)
        {
            TotalCount = totalCount;
            TotalPage = totalPage;
            CurrentPage = currentPage;
            ItemsPerPage = itemsPerPage;
        }
    }
}
