using System.Text.Json;
using WeatherAPIWrapperService.Models;

namespace WeatherAPIWrapperService.Services
{
    public class ExternalWeatherApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ExternalWeatherApiService(IHttpClientFactory httpClientFactory, IConfiguration configuration) 
        { 
            this._httpClientFactory = httpClientFactory;
            this._configuration = configuration;
        }

        public async Task<WeatherResponse?> GetWeatherData(string city)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            
            var response = await client.GetAsync($"https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/{city}?key={_configuration["WeatherAPI:Key"]}");

            if (!response.IsSuccessStatusCode)
            {
                return null; 
            }

            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var apiWeatherResponse = JsonSerializer.Deserialize<ApiWeatherResponse>(json, options)!;

            var weatherResponse = new WeatherResponse()
            {
                ResolvedAddress =  apiWeatherResponse.ResolvedAddress,
                Day = apiWeatherResponse.Days?[0]
            };

            return weatherResponse;
        }
    }
}
