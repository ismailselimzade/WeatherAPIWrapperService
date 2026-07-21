using StackExchange.Redis;
using System.Text.Json;
using WeatherAPIWrapperService.Models;

namespace WeatherAPIWrapperService.Services
{
    public class RedisService
    {
        private readonly IConnectionMultiplexer _redis;
        public RedisService(IConnectionMultiplexer redis)
        {
            this._redis = redis;
        }

        public async Task<WeatherResponse?> GetAsync(string city)
        {
            var db = _redis.GetDatabase();
            if (await db.KeyExistsAsync(city))
            {
                var weatherResponse = JsonSerializer.Deserialize<WeatherResponse>((string)(await db.StringGetAsync(city))!);
                return weatherResponse;
            }

            return null;
        
        }

        public async Task SetAsync(WeatherResponse weatherResponse, string key, TimeSpan ttl)
        {
            var db = _redis.GetDatabase();
            var value = JsonSerializer.Serialize(weatherResponse);
            await db.StringSetAsync(key,  value, ttl);
        } 
    }
}
