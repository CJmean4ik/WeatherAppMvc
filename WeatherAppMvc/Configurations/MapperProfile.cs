using AutoMapper;
using Geocoding;
using Geocoding.Google;
using WeatherAppMvc.Models;
using WeatherAppMvc.Models.WeatherForecastResponceModels;

namespace WeatherAppMvc.Configurations
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<GoogleAddress, CurrentLocationModel>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FormattedAddress))
                .ForMember(dest => dest.LON, opt => opt.MapFrom(src => src.Coordinates.Longitude))
                .ForMember(dest => dest.LAT, opt => opt.MapFrom(src => src.Coordinates.Latitude));

            CreateMap<WeatherData, WeatherForecastModel>()
               .ForMember(dest => dest.CurrentDateForecast, opt => opt.MapFrom(src => DateTime.Parse(src.dt_txt)))
               .ForMember(dest => dest.CurrentTemperature, opt => opt.MapFrom(src => src.Main.Temp))
               .ForMember(dest => dest.TemperatureFeels, opt => opt.MapFrom(src => src.Main.Feels_like))
               .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Weather[0].Description))
               .ForMember(dest => dest.IconName, opt => opt.MapFrom(src => src.Weather[0].Icon))
               .ForMember(dest => dest.WindSpeed, opt => opt.MapFrom(src => src.Wind.Speed))
               .ForMember(dest => dest.WindDirection, opt => opt.MapFrom(src => src.Wind.Deg))
               .ForMember(dest => dest.WindGusts, opt => opt.MapFrom(src => src.Wind.Gust));
        }
    }
}
