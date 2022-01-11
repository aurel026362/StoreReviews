using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StoreReview.Core.Domain;
using StoreReview.Web.Services;
using StoreReview.Web.ViewModels;

namespace StoreReview.Web.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IOptions<AuthOptions> _authOptions;
        private readonly IFacebookAuthService _facebookAuthService;

        public AccountController(UserManager<User> userManager, IOptions<AuthOptions> authOptions, IFacebookAuthService facebookAuthService)
        {
            _userManager = userManager;
            _authOptions = authOptions;
            _facebookAuthService = facebookAuthService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthenticationResultViewModel>> Register([FromBody] RegisterViewModel input, [FromQuery] bool isExternalAuth = false)
        {
            var message = "User already registered!";
            try
            {

                User user = await _userManager.FindByNameAsync(input.UserName);
                if (user == null)
                {
                    user = new User()
                    {
                        UserName = input.UserName,
                        Email = input.Email,
                        FirstName = input.FirstName,
                        LastName = input.LastName
                        //PictureUrl = input.PictureUrl
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
                    return Ok(new AuthenticationResultViewModel
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        UserId = user.Id,
                        UserName = user.UserName,
                        //PictureUrl = user.PictureUrl,
                        AccessToken = accessToken,
                        Roles = await _userManager.GetRolesAsync(user)
                    });
                }
                else
                {
                    return BadRequest(message);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationResultViewModel>> Login([FromBody] LoginViewModel input)
        {
            var user = await _userManager.FindByNameAsync(input.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, input.Password))
            {
                var token = await GenerateJWT(user);
                return Ok(new AuthenticationResultViewModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    UserId = user.Id,
                    UserName = user.UserName,
                    //PictureUrl = user.PictureUrl,
                    AccessToken = token,
                    Roles = await _userManager.GetRolesAsync(user)
                });
            }
            return NotFound();
        }

        [HttpPost("login-with-facebook")]
        public async Task<ActionResult<AuthenticationResultViewModel>> LoginWithFacebook([FromBody] LoginWithFacebookViewModel input)
        {
            var validatedToken = await _facebookAuthService.ValidateAccessTokenAsync(input.AccessToken);
            if (!validatedToken.Data.IsValid)
            {
                return BadRequest("Couldn't obtain facebook data!");
            }
            var userInfo = await _facebookAuthService.GetUserInfoAsync(input.AccessToken);
            var userName = string.Concat(userInfo.FirstName, userInfo.LastName, userInfo.Id);
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return await Register(new RegisterViewModel()
                {
                    FirstName = userInfo.FirstName,
                    LastName = userInfo.LastName,
                    PictureUrl = userInfo.Picture.Data.Url.ToString(),
                    Email = string.Concat(userName, "@mail.com"),
                    UserName = userName,
                    Roles = new List<string>
                    {
                        "User"
                    }
                }, true);
            }
            var accessToken = await GenerateJWT(user);
            return Ok(new AuthenticationResultViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserId = user.Id,
                UserName = user.UserName,
                AccessToken = accessToken,
                //PictureUrl = user.PictureUrl,
                Roles = await _userManager.GetRolesAsync(user)
            });
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
