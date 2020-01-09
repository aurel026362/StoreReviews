using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.Domain
{
    public class ShopReview : Entity
    {
        public string Description { get; set; }
        public ShopReview[] Replies { get; set; }
        public DateTime Date { get; set; }
        public float Ratting { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public long ShopId { get; set; }
        public Shop Shop { get; set; }
        public ShopReviewPhoto[] Photos { get; set; }
    }
}
