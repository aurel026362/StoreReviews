using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.DtoModels
{
    public class PagedResultDto<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public IList<T> Results { get; set; }
    }
}
