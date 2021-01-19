using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.Domain
{
    public class ReviewPhoto : Entity
    {
        public string Url { get; set; }
        public long ReviewId { get; set; }
        public Review Review { get; set; }
    }
}
