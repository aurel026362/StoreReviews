using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using StoreReview.Core.Interfaces;

namespace StoreReivew.Web.Services
{
    public class HttpContextCurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContextCurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Email
        {
            get
            {
                HttpContext httpContext = _httpContextAccessor.HttpContext;
                return httpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("emailaddress"))?.Value;
            }
        }

        public long? Id
        {
            get
            {
                HttpContext httpContext = _httpContextAccessor.HttpContext;
                var id = httpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier"))?.Value;
                return string.IsNullOrEmpty(id) ? null : Convert.ToInt64(id);
            }
        }

        public string Role
        {
            get
            {
                HttpContext httpContext = _httpContextAccessor.HttpContext;
                return httpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("role"))?.Value;
            }
        }
    }
}
