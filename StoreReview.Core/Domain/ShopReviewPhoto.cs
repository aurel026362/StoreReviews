using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.Domain
{
    public class ShopReviewPhoto : Entity
    {
        public string Url { get; set; }
        public long ShopReviewId { get; set; }
        public ShopReview ShopReview { get; set; }
    }
}
