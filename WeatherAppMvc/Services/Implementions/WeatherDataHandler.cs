using WeatherAppMvc.Models;
using WeatherAppMvc.Models.WeatherForecastResponceModels;
using WeatherAppMvc.Services.Interfaces;

namespace WeatherAppMvc.Services.Implementions
{
    public class WeatherDataHandler : IWeatherDataHandler
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public WeatherDataHandler(IHttpClientFactory httpClientFactory,IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpClient = _httpClientFactory.CreateClient();
        }

        public async Task<HttpResponseMessage> GetWeatherDataResponceAsync(string city, TimelineWeather timeline)
        {
            string API_KEY = _configuration["Keys:Api:OpenWeatherApi"]!;
            string API_URL = _configuration["URLS:Openweathermap"]!;
            int TIMELINE_COUNT = (int)timeline;

            API_URL = API_URL.Replace("CITY", city)
                             .Replace("COUNT", TIMELINE_COUNT.ToString())
                             .Replace("APIKEY", API_KEY);

            var httpResponce = await _httpClient.GetAsync(API_URL);
            return httpResponce;
        }

        public async Task<WeatherApiResponse> ParseWeatherDataResponceAsync(HttpResponseMessage httpResponse)
        {
            var weatherApiData = await httpResponse.Content.ReadFromJsonAsync<WeatherApiResponse>();
            return weatherApiData!;
        }
    }
}
