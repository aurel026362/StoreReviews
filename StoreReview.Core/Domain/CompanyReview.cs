using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.Domain
{
    public class CompanyReview : Review
    {
        public long? CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
