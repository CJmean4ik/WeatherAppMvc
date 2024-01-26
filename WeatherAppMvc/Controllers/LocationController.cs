using Microsoft.AspNetCore.Mvc;
using WeatherAppMvc.Models;
using WeatherAppMvc.Services.Interfaces;

namespace WeatherAppMvc.Controllers
{
    public class LocationController : Controller
    {
        private readonly IGeocodingHandler _geocodingHandler;

        public LocationController(IGeocodingHandler geocodingHandler)
        {
            _geocodingHandler = geocodingHandler;
        }

        [HttpPost("/weather/location")]
        public async Task<ActionResult> SearchLocation([FromForm] string country)
        {
            ViewBag.CityName = country;
            List<CurrentLocationModel>? currentLocations = null;

            if (country != null)
                currentLocations = await _geocodingHandler.GetCurrentLocation(country!.ToLower());
            
            if (currentLocations != null && currentLocations.Count != 0) ViewBag.isCitySearched = true;

            return View("cityInfo", currentLocations);
        }

        [HttpPost("/weather/location/selected")]
        public ActionResult SelectedLocation([FromForm] string selectedCity)
        {
            ViewBag.SelectedCity = selectedCity;
            return View("currentCity");
        }
    }
}
