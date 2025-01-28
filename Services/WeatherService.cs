using System.Diagnostics;
using System.Net.Http.Json;
using Weather.Models;

namespace Weather.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private const string API_KEY = "4360c841b1eff73189b2af0b9c157269";
        private const string BASE_URL = "https://api.openweathermap.org/data/2.5";

        public WeatherService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<WeatherData> GetWeatherDataAsync(double latitude, double longitude)
        {
            try
            {
                var response = await _httpClient.GetAsync(
                    $"{BASE_URL}/weather?lat={latitude}&lon={longitude}&units=metric&appid={API_KEY}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<WeatherData>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error getting weather data: {ex.Message}");
                throw;
            }
        }
    }
}
