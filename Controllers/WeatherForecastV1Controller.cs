using Microsoft.AspNetCore.Mvc;
using dot_dotnet_test_api.Models;

namespace dot_dotnet_test_api.Controllers;

[ApiController]
[Route("api/v1/weather-forecast")]
public class WeatherForecastV1Controller : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastV1Controller> _logger;

    public WeatherForecastV1Controller(ILogger<WeatherForecastV1Controller> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecastV1> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecastV1
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
