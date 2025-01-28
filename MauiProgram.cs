﻿using Weather.Services;
using Weather.ViewModels;
using Weather.Views;

namespace Weather
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


            builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
            // Register services
            builder.Services.AddSingleton<IWeatherService, WeatherService>();
            builder.Services.AddSingleton<WeatherViewModel>();
            builder.Services.AddSingleton<MainPage>();

            return builder.Build();
        }
    }
}