# Weather API Wrapper Service

A REST API that wraps the Visual Crossing weather API, caches responses with Redis, and serves weather data for any city.  
Visual Crossing hava API-sini əhatə edən, cavabları Redis ilə keşləyən və istənilən şəhər üçün hava məlumatı təqdim edən REST API.

---

## Features / Xüsusiyyətlər

- Retrieves current weather data from the Visual Crossing API.  
  Visual Crossing API-dən cari hava məlumatlarını alır.

- Caches each city's response in Redis for 1 hour, reducing unnecessary external API calls.  
  Hər şəhərin cavabını 1 saat ərzində Redis-də keşləyir, lazımsız xarici API çağırışlarının qarşısını alır.

- Returns temperature, humidity, wind speed, and weather conditions for the requested city.  
  Tələb olunan şəhər üçün temperatur, rütubət, külək sürəti və hava şəraitini qaytarır.

---

## What I Learned / Öyrəndiklərim

- How to consume a third-party API and map its response to custom models.  
  Üçüncü tərəf API-dən məlumat alıb cavabı öz modellərinə necə uyğunlaşdırmaq olar.

- How to integrate Redis as a caching layer to avoid redundant external API calls.  
  Təkrarlanan xarici API çağırışlarının qarşısını almaq üçün Redis-i keş qatı kimi necə inteqrasiya etmək olar.

- How to store and retrieve JSON data in Redis with a TTL (time-to-live).  
  Redis-də JSON məlumatları TTL (yaşama müddəti) ilə necə saxlamaq və əldə etmək olar.

- How to separate responsibilities across services (ExternalWeatherApiService, RedisService, WeatherService).  
  Məsuliyyətləri servislər arasında necə bölmək olar (ExternalWeatherApiService, RedisService, WeatherService).

- How to store sensitive configuration like API keys using .NET User Secrets.  
  API açarları kimi həssas konfiqurasiya məlumatlarını .NET User Secrets ilə necə saxlamaq olar.

---

## Tech Stack / Texnologiyalar

C#, ASP.NET Core, Redis, Visual Crossing Weather API

---

## Endpoint

| Method | URL | Description |
|--------|-----|-------------|
| GET | `/weather/{city}` | Returns weather data for the specified city. / Göstərilən şəhər üçün hava məlumatlarını qaytarır. |

### Example Response / Nümunə Cavab

```json
{
  "resolvedAddress": "Baku, Azerbaijan",
  "day": {
    "temp": 28.5,
    "tempMax": 33.0,
    "tempMin": 22.1,
    "humidity": 65.0,
    "conditions": "Partially cloudy",
    "windSpeed": 14.2
  }
}
```

---

## Setup / Quraşdırma

1. Clone the repository.  
   Repozitorini kopyalayın.

2. Add your Visual Crossing API key using .NET User Secrets.  
   Visual Crossing API açarınızı .NET User Secrets vasitəsilə əlavə edin.
   
   `dotnet user-secrets set "WeatherAPI:Key" "your_api_key_here"`

3. Make sure Redis is running on `localhost:6379`.  
   Redis-in `localhost:6379`-da işlədiyinə əmin olun.

4. Run the project.  
   Proyekti işə salın.
   
   `dotnet run`
