using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreReview.Web.ViewModels
{
    public class AuthenticationResultViewModel
    {
        public long UserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccessToken { get; set; }
        public string PictureUrl { get; set; }
        public IList<string> Roles { get; set; }
    }
}
