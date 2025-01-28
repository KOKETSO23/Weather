using Weather.Models;

namespace Weather.Services
{
    public interface IWeatherService
    {
        Task<WeatherData> GetWeatherDataAsync(double latitude, double longitude);
    }
}
