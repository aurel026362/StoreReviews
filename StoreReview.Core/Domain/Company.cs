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
        public string LogoUrl { get; set; }
        public string WebSite { get; set; }
        public IEnumerable<Shop> Shops { get; set; }
        public IEnumerable<CompanyReview> Reviews { get; set; }
        public IEnumerable<CompanyPhoto> Photos { get; set; }
    }
}
