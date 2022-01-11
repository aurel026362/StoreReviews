using StoreReview.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.Domain
{
    public class ShopFile : Entity
    {
        public File File { get; set; }
        public long FileId { get; set; }
        public Shop Shop { get; set; }
        public long ShopId { get; set; }
    }
}
