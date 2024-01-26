using WeatherAppMvc.Models;
using WeatherAppMvc.Models.WeatherForecastResponceModels;

namespace WeatherAppMvc.Services.Interfaces
{
    public interface IWeatherDataParser
    {
        List<WeatherForecastModel> GetForecastForFiveDays(WeatherApiResponse weatherData);
        List<WeatherForecastModel> GetForecastForThreeDays(WeatherApiResponse weatherData);
        List<WeatherForecastModel> GetForecastForToday(WeatherApiResponse weatherData);
        List<WeatherForecastModel> GetForecastForTomorrow(WeatherApiResponse weatherData);
    }
}
