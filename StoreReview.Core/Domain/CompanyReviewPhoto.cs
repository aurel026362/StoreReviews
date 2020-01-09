using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.Domain
{
    public class CompanyReviewPhoto : Entity
    {
        public string Url { get; set; }
        public long CompanyReviewId { get; set; }
        public CompanyReview CompanyReview { get; set; }
    }
}
