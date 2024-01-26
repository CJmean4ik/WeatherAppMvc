namespace WeatherAppMvc.Models.WeatherForecastResponceModels
{
    public class WeatherData
    {
        public Main Main { get; set; }
        public List<Weather> Weather { get; set; }
        public string Clouds_al { get; set; }
        public Wind Wind { get; set; }
        public string dt_txt { get; set; }
    }
}
