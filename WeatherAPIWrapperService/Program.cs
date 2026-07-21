using StackExchange.Redis;
using WeatherAPIWrapperService.Models;
using WeatherAPIWrapperService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("localhost:6379"));
builder.Services.AddScoped<RedisService>();
builder.Services.AddScoped<ExternalWeatherApiService>();
builder.Services.AddScoped<WeatherService>();
builder.Services.AddHttpClient();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/weather/{city}", async (string city, WeatherService weatherService) =>
{
    WeatherResponse? weatherResponse = await weatherService.GetWeatherResponseAsync(city);

    return weatherResponse == null ? Results.NotFound() : Results.Ok(weatherResponse);
});

app.Run();
