using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.Domain
{
    public class CompanyPhoto : Entity
    {
        public string Url { get; set; }
        public long CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
