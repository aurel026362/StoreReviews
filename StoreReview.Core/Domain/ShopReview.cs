using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.Domain
{
    public class ShopReview : Review
    {
        public long? ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}
