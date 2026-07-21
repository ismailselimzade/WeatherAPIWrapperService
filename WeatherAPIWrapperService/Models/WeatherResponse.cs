namespace WeatherAPIWrapperService.Models
{
    public class WeatherResponse
    {
        public string ResolvedAddress { get; set; } = string.Empty;
        public Day? Day{ get; set; }
    }
}
