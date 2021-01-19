using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.Interfaces
{
    public interface ICurrentUser
    {
        string Email { get; }
        long? Id { get; }
        string Role { get; }
    }
}
