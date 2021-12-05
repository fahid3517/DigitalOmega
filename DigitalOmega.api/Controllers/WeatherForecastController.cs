using DigitalOmega.api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DigitalOmega.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly D_OContext _dbContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger
            )
        {
            _logger = logger;
           // _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("Users")]
        public IEnumerable<User> GetUsers()
        {
            var res = _dbContext.Users.ToArray();

            return res;
        }
    }
}