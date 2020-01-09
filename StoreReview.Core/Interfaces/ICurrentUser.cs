using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.Interfaces
{
    public interface ICurrentUser
    {
        string UserName { get; set; }
    }
}
