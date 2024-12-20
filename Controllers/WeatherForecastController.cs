using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
 
 
        [HttpGet(Name = "GetWeatherForecast")]
        public string Get()
        {
            return "asdasdas";
        }
    }
}
