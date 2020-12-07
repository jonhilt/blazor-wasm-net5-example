using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using ExampleApp.Client.Data;
using ExampleApp.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleApp.Client
{ 
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            // builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
            builder.Services.AddScoped<ProfileService>();
            
            builder.Services.AddBlazoredLocalStorage();
            
            await builder.Build().RunAsync();
        }
    }
}
