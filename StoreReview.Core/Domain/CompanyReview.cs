using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.Domain
{
    public class CompanyReview : Entity
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public float Ratting { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public CompanyReview[] Replies { get; set; }
        public long CompanyId { get; set; }
        public Company Company { get; set; }
        public CompanyReviewPhoto[] Photos { get; set; }
    }
}
