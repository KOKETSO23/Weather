namespace Weather.Models
{
    public class WeatherData
    {
        public MainData Main { get; set; }
        public string Name { get; set; }
        public Weather[] Weather { get; set; }
    }

    public class MainData
    {
        public double Temp { get; set; }
        public double Feels_like { get; set; }
        public double Temp_min { get; set; }
        public double Temp_max { get; set; }
        public int Humidity { get; set; }
    }

    public class Weather
    {
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}

