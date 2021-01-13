using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.Domain
{
    public class Shop : Entity
    {
        public string Address { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public long CompanyId { get; set; }
        public Company Company { get; set; }
        public ShopReview[] Reviews { get; set; }
        public ShopPhoto[] Photos { get; set; }
    }
}
