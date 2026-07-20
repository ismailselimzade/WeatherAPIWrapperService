namespace WeatherAPIWrapperService.Models
{
    public class Day
    {
        public float Temp { get; set; }
        public float TempMax { get; set; }
        public float TempMin { get; set; }
        public float Humidity { get; set; }
        public string Conditions { get; set; }
        public float WindSpeed { get; set; }
    }
}
