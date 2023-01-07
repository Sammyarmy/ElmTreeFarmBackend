using ElmTreeFarmBackend.Commands;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ElmTreeFarmBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherApi _weatherApi;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherApi weatherApi)
    {
        _logger = logger;
        _weatherApi = weatherApi;
    }

    [EnableCors("AllowSpecificOrigin")]
    [HttpGet(Name = "GetWeatherLive")]
    public async Task<WeatherForecast> GetWeatherLive()
    {
        return await _weatherApi.GetWeatherLiveFromApi();
    }
}