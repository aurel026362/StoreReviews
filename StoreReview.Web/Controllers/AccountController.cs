using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StoreReview.Core.Domain;
using StoreReview.Web.ViewModels;

namespace StoreReview.Web.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        //private readonly SignInManager<User> _signInManager;
        private readonly IOptions<AuthOptions> _authOptions;

        public AccountController(UserManager<User> userManager, IOptions<AuthOptions> authOptions)
        {
            _userManager = userManager;
            //_signInManager = signInManager;
            _authOptions = authOptions;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel input)
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
                        LastName = input.LastName,
                        SecurityStamp = "test"
                    };
                    

                    IdentityResult result = await _userManager.CreateAsync(user, input.Password);
                    await _userManager.AddToRolesAsync(user, input.Roles);
                    return Ok(result);
                }
                else
                {
                    return BadRequest(message);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel input)
        {
            var user = await _userManager.FindByNameAsync(input.UserName);
            if (user!= null && await _userManager.CheckPasswordAsync(user, input.Password))
            {
                var token = await GenerateJWT(user);
                return Ok(new { access_token = token });
            }
            return Ok();
        }

        private async Task<string> GenerateJWT(User user)
        {
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

        [Authorize]
        [HttpGet("get-profile")]
        public async Task<IActionResult> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            return Ok(new
            {
                user.FullName,
                user.Email,
                user.UserName
            });
        }
    }
}
