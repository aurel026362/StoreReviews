using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StoreReview.Core.Domain;
using StoreReview.Web.ViewModels;

namespace StoreReview.Web.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly IOptions<AuthOptions> _authOptions;
        private readonly IFacebookAuthService _facebookAuthService;

        public AuthenticationService(UserManager<User> userManager, IOptions<AuthOptions> authOptions, IFacebookAuthService facebookAuthService)
        {
            _userManager = userManager;
            _authOptions = authOptions;
            _facebookAuthService = facebookAuthService;
        }

        public async Task<AuthenticationResultViewModel> Login(LoginViewModel input)
        {
            var user = await _userManager.FindByNameAsync(input.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, input.Password))
            {
                var token = await GenerateJWT(user);
                return new AuthenticationResultViewModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    UserId = user.Id,
                    UserName = user.UserName,
                    AccessToken = token
                };
            }
            throw new Exception("User with these credentials not found!");
        }

        public async Task<AuthenticationResultViewModel> LoginWithFacebook(LoginWithFacebookViewModel input)
        {

            var validatedToken = await _facebookAuthService.ValidateAccessTokenAsync(input.AccessToken);
            if (!validatedToken.Data.IsValid)
            {
                throw new Exception("Couldn't obtain facebook data!");
            }
            var userInfo = await _facebookAuthService.GetUserInfoAsync(input.AccessToken);
            var userName = string.Concat(userInfo.FirstName, userInfo.LastName, userInfo.Id);
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                var result = await Register(new RegisterViewModel()
                {
                    FirstName = userInfo.FirstName,
                    LastName = userInfo.LastName,
                    Email = string.Concat(userName, "@mail.com"),
                    UserName = userName,
                    Roles = new List<string>
                    {
                        "User"
                    }
                }, true);
                return result;
            }
            var accessToken = await GenerateJWT(user);
            return new AuthenticationResultViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserId = user.Id,
                UserName = user.UserName,
                AccessToken = accessToken
            };
        }

        public async Task<AuthenticationResultViewModel> Register(RegisterViewModel input, bool isExternalAuth = false)
        {
            var message = "User already registered!";

            User user = await _userManager.FindByNameAsync(input.UserName);
            if (user == null)
            {
                user = new User()
                {
                    UserName = input.UserName,
                    Email = input.Email,
                    FirstName = input.FirstName,
                    LastName = input.LastName
                };
                IdentityResult result;
                if (!isExternalAuth)
                {
                    result = await _userManager.CreateAsync(user, input.Password);
                }
                else
                {

                    result = await _userManager.CreateAsync(user);
                }
                if (!result.Succeeded)
                {
                    throw new Exception(string.Concat(result.Errors));
                }
                await _userManager.AddToRolesAsync(user, input.Roles);
                var accessToken = await GenerateJWT(user);
                return new AuthenticationResultViewModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    UserId = user.Id,
                    UserName = user.UserName,
                    AccessToken = accessToken
                };
            }
            else
            {
                throw new Exception(message);
            }
        }

        private async Task<string> GenerateJWT(User user)
        {
            if (user == null)
            {
                throw new Exception("User object is null. Cannot generate the token.");
            }
            var authParams = _authOptions.Value;

            var securityKey = authParams.GetSymetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim("role", role.ToString()));
            }

            var token = new JwtSecurityToken(authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
