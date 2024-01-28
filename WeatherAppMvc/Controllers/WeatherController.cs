using Microsoft.AspNetCore.Mvc;
using WeatherAppMvc.Models;
using WeatherAppMvc.Models.WeatherForecastResponceModels;
using WeatherAppMvc.Services.Interfaces;

namespace WeatherAppMvc.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherDataHandler _weatherHandler;
        private readonly IWeatherDataParser _weatherParser;

        public WeatherController(IWeatherDataHandler weatherHandler, IWeatherDataParser weatherParser)
        {
            _weatherHandler = weatherHandler;
            _weatherParser = weatherParser;
        }

        [HttpGet("/")]
        public ActionResult GetStartedPage() => View("Index");
        
        [HttpGet("/weather/location/forecast/for/today")]
        public async Task<ActionResult> GetTodayForecast([FromQuery] string city)
        {
            WeatherApiResponse weatherResponceData = await GetWeatherApiResponceByTimeLine(city, TimelineWeather.Today);

            var weatherData = _weatherParser.GetForecastForToday(weatherResponceData);

            ViewBag.SelectedCity = city;
            return View("currentCity", weatherData);
        }

        [HttpGet("/weather/location/forecast/for/tomorrow")]
        public async Task<ActionResult>  GetTomorrowForecast([FromQuery] string city)
        {
            WeatherApiResponse weatherResponceData = await GetWeatherApiResponceByTimeLine(city, TimelineWeather.Tomorrow);

            var weatherData = _weatherParser.GetForecastForTomorrow(weatherResponceData);

            ViewBag.SelectedCity = city;
            return View("currentCity", weatherData);
        }

        [HttpGet("/weather/location/forecast/for/three_days")]
        public async Task<ActionResult> GetThreeDaysForecast([FromQuery] string city)
        {
            WeatherApiResponse weatherResponceData = await GetWeatherApiResponceByTimeLine(city, TimelineWeather.ThreeDay);

            var weatherData = _weatherParser.GetForecastForThreeDays(weatherResponceData);

            ViewBag.SelectedCity = city;
            return View("currentCity", weatherData);
        }

        [HttpGet("/weather/location/forecast/for/five_days")]
        public async Task<ActionResult> GetFiveDaysForecast([FromQuery] string city)
        {
            WeatherApiResponse weatherResponceData = await GetWeatherApiResponceByTimeLine(city, TimelineWeather.FiveDay);
            
            var weatherData = _weatherParser.GetForecastForFiveDays(weatherResponceData);

            ViewBag.SelectedCity = city;
            return View("currentCity", weatherData);
        }

        private async Task<WeatherApiResponse> GetWeatherApiResponceByTimeLine(string city, TimelineWeather timeline)
        {
            var httpResponseMessage = await _weatherHandler.GetWeatherDataResponceAsync(city.Replace("'", ""), timeline);
            var weatherResponceData = await _weatherHandler.ParseWeatherDataResponceAsync(httpResponseMessage);
            return weatherResponceData;
        }
    }
}
