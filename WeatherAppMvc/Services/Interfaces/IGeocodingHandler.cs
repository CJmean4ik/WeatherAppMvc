using WeatherAppMvc.Models;

namespace WeatherAppMvc.Services.Interfaces
{
    public interface IGeocodingHandler
    {
        Task<List<CurrentLocationModel>> GetCurrentLocation(string location);
    }
}
