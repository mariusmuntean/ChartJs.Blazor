using System;
using System.Linq;
using System.Threading.Tasks;

namespace ChartJs.Blazor.Sample.Shared.Services
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate, int amountDays)
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, amountDays * 24).Select(index => new WeatherForecast
            {
                Date = startDate.AddHours(index).AddMilliseconds(rng.NextDouble()*1000),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray());
        }

        public Task<WeatherForecast[]> GetStaticForecastAsync(DateTime startDate, int amountDays)
        {
            return Task.FromResult(Enumerable.Range(1, amountDays * 24).Select(index => new WeatherForecast
            {
                Date = startDate.AddHours(index),
                TemperatureC = (int)(index * 2.3),
                Summary = Summaries[index % Summaries.Length]
            }).ToArray());
        }
    }
}