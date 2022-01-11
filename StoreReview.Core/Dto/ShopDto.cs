using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.DtoModels
{
    public class ShopDto
    {
        public long Id { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public float Ratting { get; set; }
        public string Phone { get; set; }
        public long CompanyId { get; set; }
        public string CompanyName { get; set; }
        public IEnumerable<string> PhotoUrls { get; set; }
    }
}
