namespace WeatherAPIWrapperService.Models
{
    public class ApiWeatherResponse
    {
        public string ResolvedAddress { get; set; } = string.Empty;
        public List<Day>? Days { get; set; }
    }
}
