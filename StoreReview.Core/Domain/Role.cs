using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.Domain
{
    public class Role : Entity
    {
        public string Description { get; set; }
        public User[] Users { get; set; }
    }
}
