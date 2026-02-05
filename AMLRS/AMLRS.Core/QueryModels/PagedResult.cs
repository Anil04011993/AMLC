using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Core.QueryModels
{
    public class PagedResult<T>
    {
        public int TotalRecords { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public List<T> Users { get; set; } = new();
    }
}

