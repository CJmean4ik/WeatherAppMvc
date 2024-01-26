using Xunit;
using Moq;
using Microsoft.Extensions.Configuration;
using WeatherAppMvc.Services.Implementions;
using WeatherAppMvc.Models;

namespace WeatherAppMvc_Test
{
    public class WeatherDataHandler_Test
    {
        [Fact]
        public async Task GetWeatherData_OdessaCityForecastToday_HttpResponceOkReturn()
        {
            //Arrange
            string CITY = "Myrne,Odesa Oblast, Ukraine, 67652";
            TimelineWeather TIMELINE = TimelineWeather.Today;

            var MOCK_CONFIGURATION = CreateIConfiguration();
            var MOCK_HTTPCLIENT = CreateIHttpClientFactory();

            var weatherDataHandler = new WeatherDataHandler(MOCK_HTTPCLIENT.Object,MOCK_CONFIGURATION.Object);

            //Act
            var httpResonceMessage = await weatherDataHandler.GetWeatherDataResponceAsync(CITY, TIMELINE);

            //Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, httpResonceMessage.StatusCode);
        }

        [Theory]
        [InlineData("Myrne,Odesa Oblast, Ukraine, 67652", TimelineWeather.Today)]
        [InlineData("Myrne,Odesa Oblast, Ukraine, 67652", TimelineWeather.Tomorrow)]
        [InlineData("Myrne,Odesa Oblast, Ukraine, 67652", TimelineWeather.ThreeDay)]
        [InlineData("Myrne,Odesa Oblast, Ukraine, 67652", TimelineWeather.FiveDay)]
        public async Task GetWeatherData_OdessaCityForecastToday_CollectionCount8Returns(string CITY, TimelineWeather TIMELINE)
        {
            //Arrange
            var MOCK_CONFIGURATION = CreateIConfiguration();
            var MOCK_HTTPCLIENT = CreateIHttpClientFactory();
            var weatherDataHandler = new WeatherDataHandler(MOCK_HTTPCLIENT.Object, MOCK_CONFIGURATION.Object);

            //Act
            var httpResonceMessage = await weatherDataHandler.GetWeatherDataResponceAsync(CITY, TIMELINE);
            var weatherData = await weatherDataHandler.ParseWeatherDataResponceAsync(httpResonceMessage);

            //Assert
            Assert.Equal((int)TIMELINE, weatherData.Cnt);
        }

        private Mock<IConfiguration> CreateIConfiguration()
        {
            var MOCK_CONFIGURATION = new Mock<IConfiguration>();
            MOCK_CONFIGURATION.Setup(x => x["URLS:Openweathermap"])
                              .Returns("https://api.openweathermap.org/data/2.5/forecast?q=CITY&units=metric&cnt=COUNT&appid=APIKEY");
            MOCK_CONFIGURATION.Setup(x => x["Keys:Api:OpenWeatherApi"])
                              .Returns("c02641ad74297c4f67e4e917dca8a150");

            return MOCK_CONFIGURATION;

        }
        private Mock<IHttpClientFactory> CreateIHttpClientFactory()
        {
            var MOCK_HTTPCLIENT = new Mock<IHttpClientFactory>();
            MOCK_HTTPCLIENT.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(new HttpClient());

            return MOCK_HTTPCLIENT;
        }
    }
}
