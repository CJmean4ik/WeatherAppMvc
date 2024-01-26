using AutoMapper;
using Moq;
using WeatherAppMvc.Models;
using WeatherAppMvc.Models.WeatherForecastResponceModels;
using WeatherAppMvc.Services.Implementions;
using Xunit;

namespace WeatherAppMvc_Test
{
    public class WeatherDataParser_Test
    {
        [Fact]
        public void ParseTodayWeatherData_WeatherApiResponse_ListWeatherForecastModelReturns()
        {
            //Arrage
            var MOCK_MAPPER = new Mock<IMapper>();
            MOCK_MAPPER.Setup(s => s.Map<WeatherData, WeatherForecastModel>(It.IsAny<WeatherData>()))
                       .Returns((WeatherData source) => GetWeatherForecastModel(source));

            var weatherDataParser = new WeatherDataParser(MOCK_MAPPER.Object);

            //Act
            var weatherForecastModels = weatherDataParser.GetForecastForToday(GetWeatherApiResponse());

            //Asserts
            Assert.Equal(5, weatherForecastModels.Count);
        }

        private WeatherApiResponse GetWeatherApiResponse()
        {
            var forecastModel = new WeatherApiResponse
            {
                Cod = "200",
                Cnt = 5,
                List = new List<WeatherData>
                    {
                        new WeatherData
                        {
                            Main = new Main
                            {
                                Temp = 1.17,
                                Feels_like = -2.15
                            },
                            Weather = new List<Weather>
                            {
                                new Weather
                                {
                                    Description = "пасмурно",
                                    Icon = "04d"
                                }
                            },
                            Clouds_al = "100",
                            Wind = new Wind
                            {
                                Speed = 3.07,
                                Deg = 193,
                                Gust = 7.16
                            },
                            dt_txt = "2024-01-26 12:00:00"
                        },
                        new WeatherData
                        {
                            Main = new Main
                            {
                                Temp = 1.16,
                                Feels_like = -1.9
                            },
                            Weather = new List<Weather>
                            {
                                new Weather
                                {
                                    Description = "небольшой снег",
                                    Icon = "13n"
                                }
                            },
                            Clouds_al = "100",
                            Wind = new Wind
                            {
                                Speed = 2.77,
                                Deg = 178,
                                Gust = 6.77
                            },
                            dt_txt = "2024-01-26 15:00:00"
                        },
                        new WeatherData
                        {
                            Main = new Main
                            {
                                Temp = 1.08,
                                Feels_like = -1.68
                            },
                            Weather = new List<Weather>
                            {
                                new Weather
                                {
                                    Description = "небольшой дождь",
                                    Icon = "10n"
                                }
                            },
                            Clouds_al = "100",
                            Wind = new Wind
                            {
                                Speed = 2.44,
                                Deg = 169,
                                Gust = 6.17
                            },

                            dt_txt = "2024-01-26 18:00:00"
                        },
                        new WeatherData
                        {
                            Main = new Main
                            {
                                Temp = 1.13,
                                Feels_like = -1.89
                            },
                            Weather = new List<Weather>
                            {
                                new Weather
                                {
                                    Description = "пасмурно",
                                    Icon = "04n"
                                }
                            },
                            Clouds_al = "100",
                            Wind = new Wind
                            {
                                Speed = 2.71,
                                Deg = 166,
                                Gust = 7.22
                            },

                            dt_txt = "2024-01-26 21:00:00"
                        },
                        new WeatherData
                        {
                            Main = new Main
                            {
                                Temp = 0.77,
                                Feels_like = -0.98
                            },
                            Weather = new List<Weather>
                            {
                                new Weather
                                {
                                    Description = "пасмурно",
                                    Icon = "04n"
                                }
                            },
                            Clouds_al = "100",
                            Wind = new Wind
                            {
                                Speed = 1.57,
                                Deg = 126,
                                Gust = 4.23
                            },
                           dt_txt = "2024-01-27 00:00:00"
                        }
                    }
            };

            return forecastModel;
        }
        private WeatherForecastModel GetWeatherForecastModel(WeatherData source)
        {
            return new WeatherForecastModel
            {
                CurrentDateForecast = DateTime.Parse(source.dt_txt),
                CurrentTemperature = source.Main.Temp,
                TemperatureFeels = source.Main.Feels_like,
                Description = source.Weather[0].Description,
                IconName = source.Weather[0].Icon,
                WindSpeed = source.Wind.Speed,
                WindDirection = source.Wind.Deg,
                WindGusts = source.Wind.Gust
            };
        }
    }
}
