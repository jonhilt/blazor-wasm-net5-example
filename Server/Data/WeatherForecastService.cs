using System;
using System.Linq;
using System.Threading.Tasks;
using ExampleApp.Shared;
using Microsoft.Extensions.Caching.Memory;

namespace ExampleApp.Server.Data
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IMemoryCache _memoryCache;

        public WeatherForecastService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<WeatherForecast[]> GetForecastAsync()
        {
            return _memoryCache.GetOrCreate("WeatherData", e =>
            {
                e.SetOptions(new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });
                
                var rng = new Random();
                return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                    {
                        Date = DateTime.Now.AddDays(index),
                        TemperatureC = rng.Next(-20, 55),
                        Summary = Summaries[rng.Next(Summaries.Length)]
                    })
                    .ToArray();
            });
        }
    }
}