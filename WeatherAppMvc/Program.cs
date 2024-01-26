using WeatherAppMvc.Services.Implementions;
using WeatherAppMvc.Services.Interfaces;

namespace WeatherAppMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
  
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IGeocodingHandler, GeocodingHandler>()
                            .AddScoped<IWeatherDataParser, WeatherDataParser>()
                            .AddScoped<IWeatherDataHandler, WeatherDataHandler>();

            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddHttpClient();

            var app = builder.Build();
       
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.MapControllers();

            app.Run();
        }
    }
}