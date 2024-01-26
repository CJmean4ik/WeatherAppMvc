namespace WeatherAppMvc.Models.WeatherForecastResponceModels
{
    public class WeatherApiResponse
    {
        public string Cod { get; set; }
        public int Cnt { get; set; }
        public List<WeatherData> List { get; set; }
    }
}
