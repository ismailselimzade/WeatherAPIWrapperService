namespace WeatherAPIWrapperService.Models
{
    public class ApiWeatherResponse
    {
        public string ResolvedAddress { get; set; }
        public List<Day> Days { get; set; }
    }
}
