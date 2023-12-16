using Asignaturas.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Asignaturas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        public IUser _hello;
        AsignaturesContext _dbcontext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IUser hello, AsignaturesContext dbcontext)
        {
            _logger = logger;
            _hello = hello;
            _dbcontext = dbcontext;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("GetHello")]
        public IActionResult GetHello()
        {
            _logger.LogInformation("Entro al metodo correctamente");
            return Ok(_hello.Get());
        }

        [HttpGet]
        [Route("Createdb")]
        public IActionResult CreateDatabase()
        {
            try
            {
                _logger.LogDebug("Entro al metodo correctamente");
                return Ok(_dbcontext.Database.EnsureCreated());
            }
            catch (Exception ex)
            {
                _logger.LogError("Se presento una exception" + ex.Message.ToString());
                return BadRequest("Tenemos problemas tecnicos");
            }

        }
    }
}