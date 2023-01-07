using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ElmTreeFarmBackend.Commands;

public interface IWeatherApi
{
    Task<WeatherForecast> GetWeatherLiveFromApi();
}

public class WeatherApi : IWeatherApi
{
    static HttpClient client = new ();
    
    public async Task<WeatherForecast> GetWeatherLiveFromApi()
    {
        WeatherForecast forecast = null;
        var request = new HttpRequestMessage(HttpMethod.Get, "http://api.weatherapi.com/v1/current.json?key=0b06ab74843f4a11aa4151554222512&q=SG120HF&aqi=no");
        var response = await client.SendAsync(request);
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            forecast = JsonConvert.DeserializeObject<WeatherForecast>(json);
        }
        return forecast;
    }
}