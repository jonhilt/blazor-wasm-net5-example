using System.Threading.Tasks;

namespace ExampleApp.Shared
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast[]> GetForecastAsync();
    }
}