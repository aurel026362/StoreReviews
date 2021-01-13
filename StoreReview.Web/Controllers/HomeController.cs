using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StoreReview.Web.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : ControllerBase
    {
        public HomeController()
        {
        }

        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            return await Task.FromResult("Welcome!");
        }
    }
}
