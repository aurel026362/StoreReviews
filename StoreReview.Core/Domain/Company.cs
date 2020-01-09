using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.Domain
{
    public class Company : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public Shop[] Shops { get; set; }
        public CompanyReview[] Reviews { get; set; }
        public CompanyPhoto[] Photos { get; set; }
    }
}
