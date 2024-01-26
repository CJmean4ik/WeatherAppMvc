using Microsoft.AspNetCore.Mvc;
using WeatherAppMvc.Models;
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
            
            var httpResponseMessage = await _weatherHandler.GetWeatherDataResponceAsync(city.Replace("'", ""), TimelineWeather.Today);
            var weatherResponceData = await _weatherHandler.ParseWeatherDataResponceAsync(httpResponseMessage);

            var weatherData = _weatherParser.GetForecastForToday(weatherResponceData);

            ViewBag.SelectedCity = city;
            return View("currentCity", weatherData);
        }

        [HttpGet("/weather/location/forecast/for/tomorrow")]
        public async Task<ActionResult>  GetTomorrowForecast([FromQuery] string city)
        {
            var httpResponseMessage = await _weatherHandler.GetWeatherDataResponceAsync(city.Replace("'", ""), TimelineWeather.Tomorrow);
            var weatherResponceData = await _weatherHandler.ParseWeatherDataResponceAsync(httpResponseMessage);

            var weatherData = _weatherParser.GetForecastForTomorrow(weatherResponceData);

            ViewBag.SelectedCity = city;
            return View("currentCity", weatherData);
        }

        [HttpGet("/weather/location/forecast/for/three_days")]
        public async Task<ActionResult> GetThreeDaysForecast([FromQuery] string city)
        {
            var httpResponseMessage = await _weatherHandler.GetWeatherDataResponceAsync(city.Replace("'", ""), TimelineWeather.ThreeDay);
            var weatherResponceData = await _weatherHandler.ParseWeatherDataResponceAsync(httpResponseMessage);

            var weatherData = _weatherParser.GetForecastForThreeDays(weatherResponceData);

            ViewBag.SelectedCity = city;
            return View("currentCity", weatherData);
        }

        [HttpGet("/weather/location/forecast/for/five_days")]
        public async Task<ActionResult> GetFiveDaysForecast([FromQuery] string city)
        {
            var httpResponseMessage = await _weatherHandler.GetWeatherDataResponceAsync(city.Replace("'", ""), TimelineWeather.FiveDay);
            var weatherResponceData = await _weatherHandler.ParseWeatherDataResponceAsync(httpResponseMessage);

            var weatherData = _weatherParser.GetForecastForFiveDays(weatherResponceData);

            ViewBag.SelectedCity = city;
            return View("currentCity", weatherData);
        }
    }
}
