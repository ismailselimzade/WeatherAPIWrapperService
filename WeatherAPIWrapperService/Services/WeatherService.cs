using StackExchange.Redis;
using WeatherAPIWrapperService.Models;

namespace WeatherAPIWrapperService.Services
{
    public class WeatherService
    {
        private readonly RedisService _redis;
        private readonly ExternalWeatherApiService _externalWeatherApiService;

        public WeatherService(RedisService redis, ExternalWeatherApiService externalWeatherApiService) 
        {
            this._redis = redis;
            this._externalWeatherApiService = externalWeatherApiService;
        }

        public async Task<WeatherResponse?> GetWeatherResponseAsync(string city)
        {
            var weatherResponse = await _redis.GetAsync(city);
            if (weatherResponse == null)
            {
                weatherResponse = await _externalWeatherApiService.GetWeatherData(city);
                if (weatherResponse != null)
                {
                    await _redis.SetAsync(city, weatherResponse, TimeSpan.FromHours(1));
                }
            }

            return weatherResponse;
        }
    }
}
