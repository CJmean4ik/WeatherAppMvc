using WeatherAppMvc.Models;

namespace WeatherAppMvc.Statics
{
    public class WeatherIconsHolder
    {
        #region Dictionary with icon names and their paths

       
        private static Dictionary<string,string> _weatherIcons = new Dictionary<string, string>
            {
                ["01d"] = "/imgs/009-sunny.png",
                ["01n"] = "/imgs/010-crescent-moon.png",
                ["02d"] = "/imgs/011-clear-sky.png",
                ["02n"] = "/imgs/006-night.png",
                ["03d"] = "/imgs/007-cloud.png",
                ["03n"] = "/imgs/007-cloud.png",
                ["04d"] = "/imgs/012-broken-clouds.png",
                ["04n"] = "/imgs/012-broken-clouds.png",
                ["09d"] = "/imgs/008-rainy-day.png",
                ["09n"] = "/imgs/008-rainy-day.png",
                ["10d"] = "/imgs/003-rainy.png",
                ["10n"] = "/imgs/005-rainy-1.png",
                ["11d"] = "/imgs/004-lighting.png",
                ["11n"] = "/imgs/004-lighting.png",
                ["13d"] = "/imgs/001-snowflake.png",
                ["13n"] = "/imgs/001-snowflake.png",
                ["50d"] = "/imgs/002-fog.png",
                ["50n"] = "/imgs/002-fog.png",
            };
        #endregion
        public static string? GetPathToImageByIconName(string iconName)
        {
            _weatherIcons.TryGetValue(iconName, out string? iconPath);                 
            return iconPath;
        }
    }
}
