using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.Domain
{
    public class ReviewFile : Entity
    {
        public File File { get; set; }
        public long FileId { get; set; }
        public Review Review { get; set; }
        public long ReviewId { get; set; }
    }
}
