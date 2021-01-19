using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.Domain
{
    public abstract class Review: Entity
    {
        public string Description { get; set; }
        public Review[] Replies { get; set; }
        public DateTime Date { get; set; }
        public float? Ratting { get; set; }
        public long UserId { get; set; }
        public ReviewPhoto[] Photos { get; set; }
        public User User { get; set; }
    }
}
