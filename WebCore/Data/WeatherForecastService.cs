using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Data
{
    public class WeatherForecastService
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate, int amountDays)
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, amountDays*24).Select(index => new WeatherForecast
            {
                Date = startDate.AddHours(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray());
        }
    }
}
