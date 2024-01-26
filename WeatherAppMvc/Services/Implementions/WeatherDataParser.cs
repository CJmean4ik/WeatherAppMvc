using AutoMapper;
using WeatherAppMvc.Models;
using WeatherAppMvc.Models.WeatherForecastResponceModels;
using WeatherAppMvc.Services.Interfaces;
using WeatherAppMvc.Statics;

namespace WeatherAppMvc.Services.Implementions
{
    public class WeatherDataParser : IWeatherDataParser
    {
        private IMapper _mapper;

        public WeatherDataParser(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<WeatherForecastModel> GetForecastForFiveDays(WeatherApiResponse weatherDataResponce)
        {
            var FORECAST_MODEL = new List<WeatherForecastModel>();

            var TOMORROW = DateTime.Now;
            TOMORROW = TOMORROW.AddDays(1).Date;

            var LIMIT_DATE = TOMORROW.AddDays(5).Date;

            foreach (var weatherData in weatherDataResponce.List)
            {
                var CURRENT_WEATHER_DATE = DateTime.Parse(weatherData.dt_txt);

                if (CURRENT_WEATHER_DATE >= TOMORROW && CURRENT_WEATHER_DATE <= LIMIT_DATE)
                {
                    var weatherModel = _mapper.Map<WeatherData, WeatherForecastModel>(weatherData);
                    weatherModel.DayWeek = DateTime.Today.DayOfWeek;
                    weatherModel.ImagePath = WeatherIconsHolder.GetPathToImageByIconName(weatherModel.IconName)!;

                    FORECAST_MODEL.Add(weatherModel);
                }
            }
            return FORECAST_MODEL;
        }

        public List<WeatherForecastModel> GetForecastForThreeDays(WeatherApiResponse weatherDataResponce)
        {
            var FORECAST_MODEL = new List<WeatherForecastModel>();

            var TOMORROW = DateTime.Now;
            TOMORROW = TOMORROW.AddDays(1).Date;

            var LIMIT_DATE = TOMORROW.AddDays(3).Date;

            foreach (var weatherData in weatherDataResponce.List)
            {
                var CURRENT_WEATHER_DATE = DateTime.Parse(weatherData.dt_txt);

                if (CURRENT_WEATHER_DATE >= TOMORROW && CURRENT_WEATHER_DATE <= LIMIT_DATE)
                {
                    var weatherModel = _mapper.Map<WeatherData, WeatherForecastModel>(weatherData);
                    weatherModel.DayWeek = DateTime.Today.DayOfWeek;
                    weatherModel.ImagePath = WeatherIconsHolder.GetPathToImageByIconName(weatherModel.IconName)!;

                    FORECAST_MODEL.Add(weatherModel);
                }
            }
            return FORECAST_MODEL;
        }

        public List<WeatherForecastModel> GetForecastForToday(WeatherApiResponse weatherDataResponce)
        {
            var FORECAST_MODEL = new List<WeatherForecastModel>();
          
            var TOMORROW = DateTime.Now;
            TOMORROW = TOMORROW.AddDays(1).Date;

            foreach (var weatherData in weatherDataResponce.List)
            {
                var CURRENT_WEATHER_DATE = DateTime.Parse(weatherData.dt_txt);

                if (CURRENT_WEATHER_DATE <= TOMORROW)
                {
                    var weatherModel = _mapper.Map<WeatherData, WeatherForecastModel>(weatherData);
                    weatherModel.DayWeek = DateTime.Today.DayOfWeek;
                    weatherModel.ImagePath = WeatherIconsHolder.GetPathToImageByIconName(weatherModel.IconName)!;
                    
                    FORECAST_MODEL.Add(weatherModel);
                }
            }
            return FORECAST_MODEL;
        }

        public List<WeatherForecastModel> GetForecastForTomorrow(WeatherApiResponse weatherDataResponce)
        {
            var FORECAST_MODEL = new List<WeatherForecastModel>();

            var TOMORROW = DateTime.Now;
            TOMORROW = TOMORROW.AddDays(1).Date;

            var LIMIT_DATE = TOMORROW.AddDays(1).Date;

            foreach (var weatherData in weatherDataResponce.List)
            {
                var CURRENT_WEATHER_DATE = DateTime.Parse(weatherData.dt_txt);

                if (CURRENT_WEATHER_DATE >= TOMORROW && CURRENT_WEATHER_DATE <= LIMIT_DATE)
                {
                    var weatherModel = _mapper.Map<WeatherData, WeatherForecastModel>(weatherData);
                    weatherModel.DayWeek = DateTime.Today.DayOfWeek;
                    weatherModel.ImagePath = WeatherIconsHolder.GetPathToImageByIconName(weatherModel.IconName)!;

                    FORECAST_MODEL.Add(weatherModel);
                }
            }
            return FORECAST_MODEL;
        }
    }
}
