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
    private readonly WeatherApi _weatherApi;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherApi weatherApi)
    {
        _logger = logger;
        _weatherApi = weatherApi;
    }
    
    // [EnableCors("AllowSpecificOrigin")]
    // [HttpGet(Name = "GetWeatherForecast")]
    // public IEnumerable<WeatherForecast> Get()
    // {
    //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //         {
    //             Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //             TemperatureC = Random.Shared.Next(-20, 55),
    //             Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //         })
    //         .ToArray();
    // }
    
    [EnableCors("AllowSpecificOrigin")]
    [HttpGet(Name = "GetWeatherLive")]
    public async Task<WeatherForecast> GetWeatherLive()
    {
        return await _weatherApi.GetWeatherLiveFromApi();
    }
}