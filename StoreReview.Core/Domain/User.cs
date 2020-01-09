using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.Domain
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public long RoleId { get; set; }
        public Role Role { get; set; }
    }
}
