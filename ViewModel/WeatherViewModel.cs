using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Weather.Models;
using Weather.Services;

namespace Weather.ViewModels
{
    public partial class WeatherViewModel : ObservableObject
    {
        private readonly IWeatherService _weatherService;
        private readonly IGeolocation _geolocation;

        [ObservableProperty]
        private WeatherData _weatherData;

        [ObservableProperty]
        private bool _isLoading;

        [ObservableProperty]
        private string _errorMessage;

        public WeatherViewModel(IWeatherService weatherService, IGeolocation geolocation)
        {
            _weatherService = weatherService;
            _geolocation = geolocation;
        }

        [RelayCommand]
        public async Task LoadWeatherData()
        {
            try
            {
                IsLoading = true;
                ErrorMessage = string.Empty;

                var location = await _geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium,
                    Timeout = TimeSpan.FromSeconds(5)
                });

                if (location != null)
                {
                    WeatherData = await _weatherService.GetWeatherDataAsync(
                        location.Latitude,
                        location.Longitude);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = "Unable to load weather data. Please try again.";
               
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}

