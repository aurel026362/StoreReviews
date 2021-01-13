using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace StoreReview.Core.Domain
{
    public class Role : IdentityRole<long>
    {
        public string Description { get; set; }
    }
}
