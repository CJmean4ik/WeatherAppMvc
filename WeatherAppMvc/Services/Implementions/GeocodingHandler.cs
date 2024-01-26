using WeatherAppMvc.Models;
using WeatherAppMvc.Services.Interfaces;
using Geocoding.Google;
using AutoMapper;
using Geocoding;

namespace WeatherAppMvc.Services.Implementions
{
    public class GeocodingHandler : IGeocodingHandler
    {
        private readonly GoogleGeocoder _geocoder;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public GeocodingHandler(IConfiguration configuration,IMapper mapper)
        {
            _configuration = configuration;
            _geocoder = new GoogleGeocoder()
            {
                ApiKey = _configuration["Keys:Api:GoogleApi"]
            };
            _mapper = mapper;
        }

        public async Task<List<CurrentLocationModel>> GetCurrentLocation(string location)
        {
            IEnumerable<GoogleAddress> addresses = await _geocoder.GeocodeAsync(location);
            var currentLocations = _mapper.Map<List<GoogleAddress>, List<CurrentLocationModel>>(addresses.ToList());
            return currentLocations;
        }
    }
}
