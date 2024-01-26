namespace WeatherAppMvc.Models
{
    public class WeatherForecastModel
    {
        public DayOfWeek DayWeek { get; set; }
        public DateTime CurrentDateForecast { get; set; }
        public double CurrentTemperature { get; set; }
        public double TemperatureFeels { get; set; }
        public string Description { get; set; } = string.Empty;
        public string IconName { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public double WindSpeed { get; set; }
        public double WindDirection { get; set; } 
        public double WindGusts { get; set; } 
    }

    public enum TimelineWeather
    {
        Today = 8,
        Tomorrow = 16,
        ThreeDay = 32,
        FiveDay = 40,
    }
    
}
