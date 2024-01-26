using Microsoft.AspNetCore.Http;
using WeatherAppMvc.Models;
using WeatherAppMvc.Models.WeatherForecastResponceModels;

namespace WeatherAppMvc.Services.Interfaces
{
    public interface IWeatherDataHandler
    {
        Task<HttpResponseMessage> GetWeatherDataResponceAsync(string city, TimelineWeather timeline);
        Task<WeatherApiResponse> ParseWeatherDataResponceAsync(HttpResponseMessage httpResponse);
    }
}
