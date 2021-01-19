using StoreReview.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreReview.Web.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResultViewModel> Login(LoginViewModel input);
        Task<AuthenticationResultViewModel> LoginWithFacebook(LoginWithFacebookViewModel input);
        Task<AuthenticationResultViewModel> Register(RegisterViewModel input, bool isExternalAuth = false);
    }
}
