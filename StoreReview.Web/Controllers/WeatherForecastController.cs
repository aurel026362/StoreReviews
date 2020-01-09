using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreReview.Core.Domain;
using StoreReview.Core.Interfaces;

namespace StoreReview.Angular.Controllers
{
    [ApiController]
    [Route("weather")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IRepository<Shop> _shopRepository;
        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IRepository<Shop> shopRepository)
        {
            _logger = logger;
            _shopRepository = shopRepository;

        }

        [HttpGet("get")]
        public IEnumerable<Shop> Get()
        {
            var results = _shopRepository.Read().ToList();
            return results.ToArray();
        }
    }
}
