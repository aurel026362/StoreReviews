using StoreReview.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.Domain
{
    public class CompanyFile : Entity
    {
        public File File { get; set; }
        public long FileId { get; set; }
        public Company Company { get; set; }
        public long CompanyId { get; set; }
    }
}
