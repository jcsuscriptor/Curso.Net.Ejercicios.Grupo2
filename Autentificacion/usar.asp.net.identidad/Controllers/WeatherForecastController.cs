using Microsoft.AspNetCore.Mvc;


namespace usar.asp.net.identidad.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    private readonly IWeatherService weatherService;
   
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(IWeatherService weatherService,
              ILogger<WeatherForecastController> logger)
    {
        this.weatherService = weatherService;
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
     
        return weatherService.Get();
    }
}




public interface IRepositoyWeather {

    IEnumerable<WeatherForecast> Get();

}

public class RepositoyWeather: IRepositoyWeather{

     private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

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

}

 
public interface IWeatherService {
    IEnumerable<WeatherForecast> Get();
}

public class WeatherServiceV1: IWeatherService{

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

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
}

public class WeatherServiceV2 : IWeatherService{
    private readonly IRepositoyWeather repositoyWeather;
    private readonly ILogger<WeatherForecastController> logger;

    public WeatherServiceV2(
        IRepositoyWeather repositoyWeather,
        ILogger<WeatherForecastController> logger)
    {
        this.repositoyWeather = repositoyWeather;
        this.logger = logger;
    }

    public IEnumerable<WeatherForecast> Get()
    {
        logger.LogInformation("Ejecutar metodo Get");

        return repositoyWeather.Get();
    }

}