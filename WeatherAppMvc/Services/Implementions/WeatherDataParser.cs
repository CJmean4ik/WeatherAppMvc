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
            var tomorrow = DateTime.Now.AddDays(1).Date;
            var limitDate = tomorrow.AddDays(5).Date;
            var forecastModels = SelectWeatherMoreThatOneDay(weatherDataResponce, tomorrow, limitDate);
            return forecastModels;
        }
        public List<WeatherForecastModel> GetForecastForThreeDays(WeatherApiResponse weatherDataResponce)
        {         
            var tomorrow = DateTime.Now.AddDays(1).Date;
            var limitDate = tomorrow.AddDays(3).Date;
            var forecastModels = SelectWeatherMoreThatOneDay(weatherDataResponce, tomorrow, limitDate);

            return forecastModels;         
        }
        public List<WeatherForecastModel> GetForecastForTomorrow(WeatherApiResponse weatherDataResponce)
        {
            var tomorrow = DateTime.Now.AddDays(1).Date;
            var limitDate = tomorrow.AddDays(1).Date;
            var forecastModels = SelectWeatherMoreThatOneDay(weatherDataResponce, tomorrow, limitDate);

            return forecastModels;
        }
        public List<WeatherForecastModel> GetForecastForToday(WeatherApiResponse weatherDataResponce)
        {
            var forecastModels = new List<WeatherForecastModel>();        
            var tomorrow = DateTime.Now.AddDays(1).Date;

            foreach (var weatherData in weatherDataResponce.List)
            {
                var currentWeatherDate = DateTime.Parse(weatherData.dt_txt);

                if (currentWeatherDate <= tomorrow)
                {
                    var weatherModel = CreateWeatherMapping(weatherData);
                    forecastModels.Add(weatherModel);
                }
            }
            return forecastModels;
        }
      
        private List<WeatherForecastModel> SelectWeatherMoreThatOneDay(WeatherApiResponse weatherDataResponce, DateTime tomorrow, DateTime limitDate)
        {
            var forecastModels = new List<WeatherForecastModel>();

            foreach (var weatherData in weatherDataResponce.List)
            {
                var currentWeatheDate = DateTime.Parse(weatherData.dt_txt);

                if (currentWeatheDate >= tomorrow && currentWeatheDate <= limitDate)
                {
                    var weatherModel = CreateWeatherMapping(weatherData);
                    forecastModels.Add(weatherModel);
                }
            }
            return forecastModels;
        }
        private WeatherForecastModel CreateWeatherMapping(WeatherData weatherData)
        {
            var weatherModel = _mapper.Map<WeatherData, WeatherForecastModel>(weatherData);
            weatherModel.DayWeek = DateTime.Today.DayOfWeek;
            weatherModel.ImagePath = WeatherIconsHolder.GetPathToImageByIconName(weatherModel.IconName)!;

            return weatherModel;
        }
    }
}
