﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreReview.Web.ViewModels
{
    public class RegisterViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string PictureUrl { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
