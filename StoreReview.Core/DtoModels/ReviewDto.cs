using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.DtoModels
{
    public class ReviewDto
    {
        public long Id { get; set; }
        public ReviewType ReviewType { get; set; }
        public string Description { get; set; }
        public bool HasReplies { get; set; }
        public DateTime Date { get; set; }
        public float? Ratting { get; set; }
        public string OwnerFullName { get; set; }
        public string UserId { get; set; }
        public long? CompanyId { get; set; }
        public long? ShopId { get; set; }
        //public ReviewPhoto[] Photos { get; set; }
        //public User User { get; set; }
    }
}
