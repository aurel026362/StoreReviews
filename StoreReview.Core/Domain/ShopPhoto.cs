using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.Domain
{
    public class ShopPhoto : Entity
    {
        public string Url { get; set; }
        public long ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}
